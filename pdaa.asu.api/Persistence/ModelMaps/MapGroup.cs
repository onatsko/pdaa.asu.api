using Dapper.FluentMap.Mapping;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence.ModelMaps
{
    public class MapGroup : EntityMappingBuilder<Group>
    {
        public MapGroup()
        {
            Map(u => u.PK).ToColumn("pkGroup");
            Map(u => u.IsDel).ToColumn("IsDel");
            Map(u => u.Name).ToColumn("GrupName");
            Map(u => u.NameAutoAll).ToColumn("GrupNameAutoAll");
            Map(u => u.NameAutoShort1).ToColumn("GrupNameAutoShort1");
            Map(u => u.NameAutoShort2).ToColumn("GrupNameAutoShort2");
            Map(u => u.Num).ToColumn("GrupNum");
            Map(u => u.SpecFK).ToColumn("IdSpec");
            Map(u => u.KvalifFK).ToColumn("IdKvalif");
            Map(u => u.KursFK).ToColumn("IdKurs");
            Map(u => u.VidEducFK).ToColumn("IdVidEduc");
            Map(u => u.IsIntegrated).ToColumn("chkIntegrated");
            Map(u => u.IntegratedNum).ToColumn("IntegratedNum");
            Map(u => u.Prim).ToColumn("Prim");
            Map(u => u.FakultetFK).ToColumn("IdFakultet");
            Map(u => u.SpecDirectFK).ToColumn("IdSpecDirect");
            Map(u => u.SpecOldFK).ToColumn("IdSpecOld");
            Map(u => u.UchPlanFK).ToColumn("IdUchPlan");

        }
    }
}
