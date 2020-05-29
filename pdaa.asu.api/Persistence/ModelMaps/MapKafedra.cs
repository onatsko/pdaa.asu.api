using Dapper.FluentMap.Mapping;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence.ModelMaps
{
    public class MapKafedra : EntityMappingBuilder<Kafedra>
    {
        public MapKafedra()
        {
            Map(u => u.PK).ToColumn("IdKafedra");
            Map(u => u.IsDel).ToColumn("IsDel");
            Map(u => u.Name).ToColumn("KafedraName");
            Map(u => u.NameShort).ToColumn("KafShortName");
            Map(u => u.NameEng).ToColumn("KafedraNameEng");
            Map(u => u.NameShortEng).ToColumn("KafShortNameEng");
            Map(u => u.IsEduc).ToColumn("FlEduc");
            Map(u => u.IsNoUs).ToColumn("chkNoUs");
            Map(u => u.PrefixForOrder).ToColumn("KafedraPrefixForOrder");
            Map(u => u.NameDavalnyi).ToColumn("KafedraNameDavalnyi");
            Map(u => u.Prim).ToColumn("Prim");
            Map(u => u.FakultetFK).ToColumn("IdFakultet");
        }
    }
}
