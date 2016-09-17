using System;
using System.Linq;
using Hazeltek.Data.Common;
using Hazeltek.UtiliTrak.Data.Domain.Network;



namespace Hazeltek.UtiliTrak.Services.Network
{
    public class PowerLineService: IPowerLineService
    {
        // fields:
        private IRepository<PowerLine> powerlineRepository;


        public PowerLineService(IRepository<PowerLine> powerlineRepository)
        {
            this.powerlineRepository = powerlineRepository;
        }

        public PowerLine GetById(int id)
        {
            if (id == 0)
                return null;
            return this.powerlineRepository.Table
                       .SingleOrDefault(p => p.Id == id && !p.Deleted);
        }

        public PowerLine GetByCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;
            return this.powerlineRepository.Table
                       .SingleOrDefault(p => p.Code.ToLower() == code.ToLower()
                                          && !p.Deleted);
        }

        public PowerLine GetByAltCode(string altCode)
        {
            if (string.IsNullOrWhiteSpace(altCode))
                return null;
            return this.powerlineRepository.Table
                       .SingleOrDefault(p => p.AltCode.ToLower() == altCode.ToLower()
                                          && !p.Deleted);
        }

        public IPagedList<PowerLine> GetPowerLines(int pageIndex=0, int pageSize=int.MaxValue,
              PowerLineType? type=null, Voltage? voltage=null, string sourceStationCode=null)
        {
            var query = this.powerlineRepository.Table;
            if (type.HasValue) {
                query = (type.Value == PowerLineType.Feeder
                      ? (IQueryable<PowerLine>)query.OfType<Feeder>()
                      : (IQueryable<PowerLine>)query.OfType<Upriser>());
            }

            if (voltage.HasValue)
                query = query.Where(p => p.Voltage == voltage);
            
            if (!string.IsNullOrWhiteSpace(sourceStationCode))
                query = query.Where(p => p.SourceStation.Code.ToLower() == sourceStationCode.ToLower());
            
            query = query.Where(p => !p.Deleted)
                         .OrderByDescending(p => p.Voltage)
                         .ThenBy(p => p.Name);
            return new PagedList<PowerLine>(query, pageIndex, pageSize);
        }
        
        public void DeletePowerLine(PowerLine powerline)
        {
            powerlineRepository.Delete(powerline);
        }

        public void InsertPowerLine(PowerLine powerline)
        {
            // TODO: use service to get datetime
            powerline.DateCreated = DateTime.Now;
            powerlineRepository.Insert(powerline);
        }

        public void UpdatePowerLine(PowerLine powerline)
        {
            // TODO: use service to get datetime
            powerline.LastUpdated = DateTime.Now;
            powerlineRepository.Update(powerline);
        }
    }
}