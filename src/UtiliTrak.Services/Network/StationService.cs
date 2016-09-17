using System;
using System.Linq;
using Hazeltek.Data.Common;
using Hazeltek.UtiliTrak.Data.Domain.Network;



namespace Hazeltek.UtiliTrak.Services.Network
{
    public class StationService: IStationService
    {
        // fields:
        private IRepository<Station> stationRepository;

        public StationService(IRepository<Station> stationRepository)
        {
            this.stationRepository = stationRepository;
        }

        public Station GetById(int stationId)
        {
            if (stationId == 0)
                return null;
            return this.stationRepository.GetById(stationId);
        }

        public Station GetByCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;
            return this.stationRepository.Table
                       .SingleOrDefault(s => s.Code.ToLower() == code.ToLower()
                                          && !s.Deleted);
        }

        public Station GetByAltCode(string altCode)
        {
            if (string.IsNullOrWhiteSpace(altCode))
                return null;
            return this.stationRepository.Table
                       .SingleOrDefault(s => s.AltCode.ToLower() == altCode.ToLower()
                                          && !s.Deleted);
        }

        public IPagedList<Station> GetProducts(int pageIndex=0, int pageSize=int.MaxValue,
               StationType? type=null, VoltageRatio? voltageRatio=null,
               string sourcePowerLineCode=null, bool? isPublic=null)
        {
            var query = this.stationRepository.Table;
            if (type.HasValue) {
                query = (type.Value == StationType.Transmission
                      ? (IQueryable<Station>)query.OfType<TransmissionStation>()
                      : type.Value == StationType.Injection
                            ? (IQueryable<Station>)query.OfType<InjectionSubstation>()
                            : (IQueryable<Station>)query.OfType<DistributionSubstation>());
            }
            
            if (voltageRatio.HasValue)
                query = query.Where(s => s.VoltageRatio == voltageRatio.Value);
            
            if (!string.IsNullOrWhiteSpace(sourcePowerLineCode))
                query = query.Where(s => s.SourcePowerLine.Code.ToLower() == sourcePowerLineCode.ToLower());
            
            if (isPublic.HasValue)
                query = query.Where(s => s.IsPublic == isPublic.Value);
            
            query = query.Where(s => !s.Deleted)
                         .OrderBy(s => s.VoltageRatio).ThenBy(s => s.Name);
            return new PagedList<Station>(query, pageIndex, pageSize);
        }

        public IPagedList<Station> GetByType<T>(bool isPublic=true, int pageIndex=0,
               int pageSize=int.MaxValue) where T: Station
        {
            var query = this.stationRepository.Table
                            .Where(s => s.IsPublic == isPublic)
                            .OfType<T>()
                            .OrderBy(s => s.Name);
            return new PagedList<Station>(query, pageIndex, pageSize);
        }

        public IPagedList<Station> GetByPowerLine(int powerLineId, bool isPublic=true,
               int pageIndex=0, int pageSize=int.MaxValue)
        {
            var query = this.stationRepository.Table
                            .Where(s => s.IsPublic == isPublic 
                                     && s.SourcePowerLineId == powerLineId
                                     && !s.Deleted)
                            .OrderBy(s => s.Name);
            return new PagedList<Station>(query, pageIndex, pageSize);
        }

        public IPagedList<Station> GetByOwnership(bool isPublic, int pageIndex=0,
               int pageSize=int.MaxValue)
        {
            var query = this.stationRepository.Table
                            .Where(s => s.IsPublic == isPublic && !s.Deleted)
                            .OrderBy(s => s.Name);
            return new PagedList<Station>(query, pageIndex, pageSize);
        }

        public void DeleteStation(Station station)
        {
            stationRepository.Delete(station);
        }

        public void InsertStation(Station station)
        {
            // TODO: use service to get datetime
            station.DateCreated = DateTime.Now;
            stationRepository.Insert(station);
        }

        public void UpdateStation(Station station)
        {
            // TODO: use service to get datetime
            station.LastUpdated = DateTime.Now;
            stationRepository.Update(station);
        }
    }


}