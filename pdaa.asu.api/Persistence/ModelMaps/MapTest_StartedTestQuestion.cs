using Dapper.FluentMap.Mapping;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence.ModelMaps
{
    public class MapTest_StartedTestQuestion : EntityMappingBuilder<Test_StartedTestQuestion>
    {
        public MapTest_StartedTestQuestion()
        {
            Map(u => u.QuestionId).ToColumn("IdQuestion");
            Map(u => u.RowNumber).ToColumn("ROW_NUM");
        }
    }
}
