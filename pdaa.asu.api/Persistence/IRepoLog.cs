using System;
using System.Collections.Generic;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence
{
    public interface IRepoLog
    {
        public void AddLog(long currentUserId, string tableName, long elementPK, string whatDo, string elementBefore, string elementAfter);
        List<LogOnd> GetLogs(string tableName, string whatDoStart, DateTime from, DateTime to);
        List<TelegramBotHistory> GetTelegramShedulerRequestLogs(DateTime from, DateTime to);
    }
}
