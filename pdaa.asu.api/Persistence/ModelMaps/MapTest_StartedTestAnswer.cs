using Dapper.FluentMap.Mapping;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence.ModelMaps
{
    public class MapTest_StartedTestAnswer : EntityMappingBuilder<Test_StartedTestAnswer>
    {
        public MapTest_StartedTestAnswer()
        {
            Map(u => u.RowNumber).ToColumn("ROW_NUM");
            Map(u => u.IdTestAnswer).ToColumn("IdTestAnswer");
            Map(u => u.IdAnswer).ToColumn("IdAnswer");
            Map(u => u.AnswerFl_fakt).ToColumn("AnswerFl_fakt");
        }
    }
}
