using Hazeltek.UtiliTrak.Data.Domain.Network;



namespace Hazeltek.UtiliTrak.Services.Network
{
    public interface IPowerLineService
    {
        PowerLine GetById(int id);

        PowerLine GetByCode(string code);

        PowerLine GetByAltCode(string altCode);

        IPagedList<PowerLine> GetPowerLines(int pageIndex=0, int pageSize=int.MaxValue,
            PowerLineType? type=null, Voltage? voltage=null, string sourceStationCode=null);
        
        void DeletePowerLine(PowerLine powerline);

        void InsertPowerLine(PowerLine powerline);

        void UpdatePowerLine(PowerLine powerline);
    }


}