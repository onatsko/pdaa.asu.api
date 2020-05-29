using Dapper.FluentMap.Mapping;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence.ModelMaps
{
    public class MapLogOnd : EntityMappingBuilder<LogOnd>
    {
        public MapLogOnd()
        {
            Map(u => u.Id).ToColumn("pkLog");
            Map(u => u.LogDate).ToColumn("LogDate");
            Map(u => u.UserId).ToColumn("fkUser");
            Map(u => u.TableName).ToColumn("TableName");
            Map(u => u.ElementId).ToColumn("ElementPk");
            Map(u => u.WhatDo).ToColumn("WhatDo");
            Map(u => u.ElementBefore).ToColumn("ElementBefore");
            Map(u => u.ElementAfter).ToColumn("ElementAfter");
        }
    }
}
