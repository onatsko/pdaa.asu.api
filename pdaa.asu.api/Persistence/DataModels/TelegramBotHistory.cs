using System;

namespace pdaa.asu.api.Persistence.DataModels
{
    public class TelegramBotHistory
    {
        public long Id { get; set; }
        public DateTime LogDate { get; set; }
        public string MessageText { get; set; }

    }
}
