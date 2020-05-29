using Dapper.FluentMap.Mapping;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence.ModelMaps
{
    public class MapTelegramBotHistory : EntityMappingBuilder<TelegramBotHistory>
    {
        public MapTelegramBotHistory()
        {
            Map(u => u.Id).ToColumn("pkTelegramBotHistory");
            Map(u => u.LogDate).ToColumn("TBHDate");
            Map(u => u.MessageText).ToColumn("MsgText");
        }
    }
}
