import os
import psycopg2
from datetime import datetime
from collections import OrderedDict
from openpyxl import load_workbook
from dolfin import Storage as _, XlSheet



#: constants
TRANSMISSION = 1
INJECTION    = 2
DISTRIBUTION = 3

FEEDER  = 1
UPRISER = 2

STATION_TYPES = (
    TRANSMISSION,
    INJECTION,
    DISTRIBUTION
)


class Voltage:
    HVOLTH, HVOLTL, MVOLTH, MVOLTL, LVOLT = range(5, 0, -1)
    _Int2Text = OrderedDict({
        HVOLTH: '330KV', HVOLTL: '132KV', MVOLTH: '33KV', MVOLTL: '11KV',
        LVOLT: '0.415KV' })
    _Text2Int = OrderedDict({
        '330KV': HVOLTH, '132KV': HVOLTL, '33KV': MVOLTH, '11KV': MVOLTL,
        '0.415KV': LVOLT })
    
    class Ratio:
        HVOLTH_HVOLTL, HVOLTL_MVOLTH, HVOLTL_MVOLTL = range(6, 3, -1)
        MVOLTH_MVOLTL, MVOLTH_LVOLT, MVOLTL_LVOLT = range(3, 0, -1)
        _Int2Text = OrderedDict({
            HVOLTH_HVOLTL: '330/132KV', HVOLTL_MVOLTH: '132/33KV',
            HVOLTL_MVOLTL: '132/11KV',  MVOLTH_MVOLTL: '33/11KV',
            MVOLTH_LVOLT: '33/0.415KV', MVOLTL_LVOLT: '11/0.415KV'
        })
        _Text2Int = OrderedDict({
            '330/132KV': HVOLTH_HVOLTL, '132/33KV': HVOLTL_MVOLTH,
            '132/11KV': HVOLTL_MVOLTL, '33/11KV': MVOLTH_MVOLTL,
            '33/0.415KV': MVOLTH_LVOLT, '11/0.415KV': MVOLTL_LVOLT
        })

class StationReader:

    def __init__(self, worksheet, station_type):
        if station_type not in STATION_TYPES:
            raise ValueError('Invalid station type provided.')
        
        self.station_type = station_type
        self.worksheet = worksheet
    
    def get_assets(self):
        assets_gen = lambda x: []
        if self.station_type == TRANSMISSION:
            assets_gen = self._get_transmission_assets
        
        cols = self._get_cols_index_info()
        return assets_gen(cols)

    def _ensure_headers_exist(self, sample_headers, row_offset=0):
        """
        Returns the index at which provided headers are found, otherwise an
        exception is raised.
        """
        index = XlSheet.find_headers(self.worksheet, sample_headers, row_offset)
        if index == -1:
            raise Exception("Headers not found: %s" % sample_headers)
        return index
    
    def _get_cols_index_info(self):
        names, indexes = (), ()
        if self.station_type == TRANSMISSION:
            names = ('ts_region', 'ts_code', 'ts_alt_code', 'ts_name', 'ts_state',
                     'xfr_code', 'xfr_alt_code', 'xfr_cap', 'fdr_volt', 'fdr_code', 
                     'fdr_alt_code', 'fdr_name', 'fdr_is_public')
            indexes = list(range(1, 9)) + list(range(10, 15))
        return _(zip(names, indexes))
    
    def _get_row_entry(self, row, label, default=''):
        return row[label] or default
    
    def _get_transmission_assets(self, cols):
        get = self._get_row_entry
        hdrs = ['ts.sn', 'ts.region', 'ts.code', 'ts.alt_code', 'ts.name']
        self._ensure_headers_exist(hdrs)

        # iterate rows and extract asset in nested-form
        station, feeders = None, None
        for row in self.worksheet:
            # new station encountered?
            if get(row, cols.ts_name):
                if station:
                    yield station
                
                station = _({
                    'region': get(row, cols.ts_region),
                    'code': get(row, cols.ts_code),
                    'alt_code': get(row, cols.ts_alt_code),
                    'name': get(row, cols.ts_name).replace("'", "''"),
                    'type': TRANSMISSION,
                    'state': get(row, cols.ts_state),
                    'voltage_ratio': Voltage.Ratio.HVOLTL_MVOLTH,
                    'transformers': [] 
                })
        
            # new transformer encountered?
            if get(row, cols.xfr_code):
                feeders = []
                station.transformers.append(_({
                    'code': get(row, cols.xfr_code),
                    'alt_code': get(row, cols.xfr_alt_code),
                    'capacity': get(row, cols.xfr_cap),
                    'feeders': feeders
                }))

            # collect feeder details
            feeders.append(_({
                'type': FEEDER,
                'code': get(row, cols.fdr_code),
                'alt_code': get(row, cols.fdr_alt_code) or "",
                'name': get(row, cols.fdr_name).replace("'", "''"),
                'voltage': Voltage._Text2Int[get(row, cols.fdr_volt)],
                'is_public': get(row, cols.fdr_is_public) == 'T'
            }))
    
        # return very last station
        if station:
            yield station


class DbHelper:

    def __init__(self, show_progress=True):
        self._show_progress = show_progress

    def get_dml_provider(self, row_provider, dml_builder):
        def dml_generator():
            for row in row_provider:
                try:
                    dml = dml_builder(row)
                    yield dml
                except Exception as ex:
                    print(ex)
                    raise ex
        return dml_generator
    
    def get_row_provider(self, conn, table_name, columns=None, extra_clause=None, 
        count=None):
        # build query text
        query = "SELECT %s FROM %s" % (
            '*' if not columns else ', '.join(columns),
            table_name
        )
        
        if extra_clause:
            query += extra_clause
        
        def read_rows():
            # execute query
            cursor = conn.cursor()
            cursor.execute()

            desc = cursor.description
            fields = [f[0] for f in desc]

            records = cursor.fetchmany(count) if count else cursor.fetchall()
            for r in records:
                yield _(zip(fields, r))
        return read_rows()

    def run_dml(self, conn, dml_provider):
        if not dml_provider:
            raise ValueError("dml_provider must be provided.")
        
        # storage for operation results summary
        results = _(failed=0, passed=0, errors=[])
        ln_count, cursor = 0, conn.cursor()
        for dml in dml_provider():
            try:
                cursor.execute(dml)
                results.passed += 1
                self._print('.', sep='', end='')
            except Exception as ex:
                results.failed += 1
                results.errors.append([ex, dml])
                self._print('F', sep='', end='')
            
            ln_count += 1
            if ln_count % 10 == 0:
                conn.commit()
            if ln_count % 100 == 0:
                self._print('')
        
        conn.commit()
        self._print("\ncount: %s | passed: %s | failed: %s" % (
            results.passed + results.failed,
            results.passed, results.failed
        ))

        if results.errors:
            print("*" * 80)
            for entry in results.errors:
                print(str(entry[0]))
                print(entry[1])
                print("-" * 10 + "\n")

    def _print(self, value, sep='', end='\n'):
        if self._show_progress:
            print(value, sep=sep, end=end, flush=True)


#+=============================================================================+

def _station_dml_builder(station):
    return """
        INSERT INTO "Station" (
            "Code", "AltCode", "Name", "Type", "VoltageRatio", 
            "IsPublic", "DateCreated"
        ) VALUES ('{}', '{}', '{}', {}, {}, {}, '{}');
    """.format(station.code, station.alt_code, station.name,
               station.type, station.voltage_ratio,
               station.is_public, station.date_created)

def _feeder_dml_builder(feeder):
    return """
        INSERT INTO "PowerLine" (
            "Code", "AltCode", "Name", "Type", "Voltage",
            "SourceStationId", "IsPublic", "DateCreated"
        ) SELECT '{0}', '{1}', '{2}', {3}, {4}, "Id", {5}, '{6}'
          FROM "Station" WHERE ("Code"='{7}' AND "Type"={8});
    """.format(feeder.code, feeder.alt_code, feeder.name,
               feeder.type, feeder.voltage, feeder.is_public, 
               feeder.date_created, feeder.station.code,
               feeder.station.type)

def insert_station(conn, reader):
    def _provider():
        today = datetime.today()
        for station in reader.get_assets():
            station.date_created = today
            station.is_public = True
            yield station
    
    # run the dmls
    db_helper = DbHelper()
    db_helper.run_dml(conn,
        db_helper.get_dml_provider(
            _provider(),
            _station_dml_builder
        )
    )

def insert_feeder(conn, reader):
    def _provider():
        today = datetime.today()
        for station in reader.get_assets():
            for t in station.transformers:
                for f in t.feeders:
                    if f.name == '-':
                        continue

                    f.date_created = today
                    f.station = station
                    yield f
    
    # run the dmls
    db_helper = DbHelper()
    db_helper.run_dml(conn,
        db_helper.get_dml_provider(
            _provider(),
            _feeder_dml_builder
        )
    )


if __name__ == '__main__':
    filepath = '/home/abdulhakeem/Dropbox/work.kedco/stations+feeders.xlsx'
    reader = StationReader(XlSheet(filepath, 'TS.&.Fdrs'), TRANSMISSION)
    conn = psycopg2.connect(host='utilitrak.hazeltek.com', database='utilitrak', user='utrak', password='utr@k#')
    #insert_station(conn, reader)
    insert_feeder(conn, reader)
