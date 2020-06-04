using Dapper.FluentMap.Mapping;
using PDAA_cs.Common.DataModels;

namespace pdaa.asu.api.Persistence.ModelMaps
{
    public class MapZnoExam : EntityMappingBuilder<ZnoExam>
    {
        public MapZnoExam()
        {
            Map(u => u.Id).ToColumn("Id");
            Map(u => u.Name).ToColumn("ExamName");
        }
    }
}
