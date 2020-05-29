using Dapper.FluentMap.Mapping;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence.ModelMaps
{
    public class MapTest_ShablonDetail : EntityMappingBuilder<Test_ShablonDetail>
    {
        public MapTest_ShablonDetail()
        {
            Map(u => u.Id).ToColumn("IdShablon");
            Map(u => u.Name).ToColumn("ShablonName");
            Map(u => u.Time).ToColumn("WayTime");
            Map(u => u.VidSysOcen).ToColumn("IdVidSysOcen");
        }
    }
}
