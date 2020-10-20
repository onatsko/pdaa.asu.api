using Dapper.FluentMap.Mapping;
using PDAA_cs.Common.DataModels;

namespace pdaa.asu.api.Persistence.ModelMaps
{
    public class MapZnoSpec : EntityMappingBuilder<ZnoSpec>
    {
        public MapZnoSpec()
        {
            Map(u => u.Id).ToColumn("Id");
            Map(u => u.Code).ToColumn("SpecCode");
            Map(u => u.Name).ToColumn("SpecName");
            Map(u => u.EducProgram).ToColumn("EducProgram");
        }
    }
}
