using Dapper.FluentMap.Mapping;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence.ModelMaps
{
    public class MapTest_Shablon : EntityMappingBuilder<Test_Shablon>
    {
        public MapTest_Shablon()
        {
            Map(u => u.Id).ToColumn("IdShablon");
            Map(u => u.Name).ToColumn("ShablonName");
        }
    }
}
