using Dapper.FluentMap.Mapping;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence.ModelMaps
{
    public class MapPosada : EntityMappingBuilder<Posada>
    {
        public MapPosada()
        {
            Map(u => u.PK).ToColumn("IdPosada");
            Map(u => u.IsDel).ToColumn("IsDel");
            Map(u => u.Name).ToColumn("PosadaName");
            Map(u => u.NameEng).ToColumn("PosadaNameEng");
            Map(u => u.NameRodovyi).ToColumn("PosadaNameRodovyi");
            Map(u => u.NameDavalnyi).ToColumn("PosadaNameDavalnyi");
            Map(u => u.NameOrudnyi).ToColumn("PosadaNameOrudnyi");
            Map(u => u.IsEduc).ToColumn("FlEduc");
            Map(u => u.IsTimesheet).ToColumn("chkTimesheet");
            Map(u => u.Prim).ToColumn("Prim");
            Map(u => u.VacationDays).ToColumn("VacationDays");
            Map(u => u.VacationDaysWorkPart).ToColumn("VacationDaysWorkPart");
            Map(u => u.VacationDaysSpecial).ToColumn("VacationDaysSpecial");
            Map(u => u.IsScientific).ToColumn("chkScientific");
            Map(u => u.IsScientificPed).ToColumn("chkScientificPed");
            Map(u => u.IsPed).ToColumn("chkPed");
            Map(u => u.IsLibrarians).ToColumn("chkLibrarians");
            Map(u => u.IsMedical).ToColumn("chkMedical");
            Map(u => u.IsNoCalc).ToColumn("chkNoCalc");
            Map(u => u.ClassificationCode).ToColumn("ClassificationCode");
        }
    }
}
