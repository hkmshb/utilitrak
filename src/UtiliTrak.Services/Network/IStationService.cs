using Hazeltek.UtiliTrak.Data.Domain.Network;



namespace Hazeltek.UtiliTrak.Services.Network
{
    public interface IStationService
    {
        Station GetById(int id);

        Station GetByCode(string code);

        Station GetByAltCode(string altCode);

        IPagedList<Station> GetProducts(int pageIndex=0, int pageSize=int.MaxValue,
            StationType? type=null, VoltageRatio? voltageRatio=null, 
            string sourcePowerLineCode=null, bool? isPublic=null);

        IPagedList<Station> GetByType<T>(bool isPublic=true, int pageIndex=0, 
            int pageSize=int.MaxValue) where T: Station;

        IPagedList<Station> GetByPowerLine(int SourcePowerLineId, bool isPublic=true,
            int pageIndex=0, int pageSize=int.MaxValue);

        IPagedList<Station> GetByOwnership(bool isPublic, int pageIndex=0,
            int pageSize=int.MaxValue);

        void DeleteStation(Station station);

        void InsertStation(Station station);

        void UpdateStation(Station station);
    }


}