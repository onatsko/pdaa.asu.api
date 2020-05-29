using System;
using System.Collections.Generic;
using System.Linq;
using pdaa.asu.api.Persistence;
using pdaa.asu.api.Services.ViewModels;

namespace pdaa.asu.api.Services
{
    public class ServicePulse
    {
        private IUnitOfWork _uow;

        public ServicePulse(IUnitOfWork uow)
        {
            _uow = uow;
        }

        /// <summary>
        /// Количество успешных входов на сайт
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public int GetAsuSuccessLoginCount(DateTime from, DateTime to)
        {
            // "exec dbo.usp_Adm_LogOnd_Logs 'BlazorSite', 0, 'Успешный вход с кодом%', '20200401', '19000101'";
            var logs = _uow.repoLog.GetLogs("BlazorSite", "Успешный вход с кодом%", from.Date, to.Date);
            if (logs == null)
                return 0;

            return logs.Count;
        }

        public List<CountByDate> GetAsuSuccessLoginCountByDay(DateTime from, DateTime to)
        {
            // "exec dbo.usp_Adm_LogOnd_Logs 'BlazorSite', 0, 'Успешный вход с кодом%', '20200401', '19000101'";
            var logs = _uow.repoLog.GetLogs("BlazorSite", "Успешный вход с кодом%", from.Date, to.Date);
            if (logs == null)
                return null;

            var result = new List<CountByDate>();
            var days = (to.Date - from.Date).Days;
            for (int i = 0; i <= days; i++)
            {
                var curDate = from.AddDays(i).Date;
                result.Add(new CountByDate()
                {
                    Date = curDate, 
                    Count = logs.Count(x => x.LogDate.Date.Equals(curDate))
                });
            }

            return result;
        }

        public List<CountByDate> GetAsuSiteEnterCountByDay(DateTime from, DateTime to)
        {
            // "exec dbo.usp_Adm_LogOnd_Logs 'BlazorSite', 0, 'Успешный вход с кодом%', '20200401', '19000101'";
            var logs = _uow.repoLog.GetLogs("BlazorSite", "Вход на сайт", from.Date, to.Date);
            if (logs == null)
                return null;

            var result = new List<CountByDate>();
            var days = (to.Date - from.Date).Days;
            for (int i = 0; i <= days; i++)
            {
                var curDate = from.AddDays(i).Date;
                result.Add(new CountByDate()
                {
                    Date = curDate,
                    Count = logs.Count(x => x.LogDate.Date.Equals(curDate))
                });
            }

            return result;
        }

        /// <summary>
        /// количество уникальных пользователей на сайте (один человек может несколько раз входить - считаем только пользователей уникальных)
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public int GetAsuSuccessLoginPersonCount(DateTime from, DateTime to)
        {
            // "exec dbo.usp_Adm_LogOnd_Logs 'BlazorSite', 0, 'Успешный вход с кодом%', '20200401', '19000101'";
            var logs = _uow.repoLog.GetLogs("BlazorSite", "Успешный вход с кодом%", from.Date, to.Date);
            if (logs == null)
                return 0;

            return logs.Select(x => x.UserId).Distinct().Count();
        }

        /// <summary>
        /// всего входов на сайт (открытие стартовой Index)
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public int GetAsuSiteEnterCount(DateTime from, DateTime to)
        {
            // "exec dbo.usp_Adm_LogOnd_Logs 'BlazorSite', 0, 'Успешный вход с кодом%', '20200401', '19000101'";
            var logs = _uow.repoLog.GetLogs("BlazorSite", "Вход на сайт", from.Date, to.Date);
            if (logs == null)
                return 0;

            return logs.Count();
        }

        public List<CountByDate> GetAsuSuccessLoginPersonCountByDay(DateTime from, DateTime to)
        {
            // "exec dbo.usp_Adm_LogOnd_Logs 'BlazorSite', 0, 'Успешный вход с кодом%', '20200401', '19000101'";
            var logs = _uow.repoLog.GetLogs("BlazorSite", "Успешный вход с кодом%", from.Date, to.Date);
            if (logs == null)
                return null;

            var result = new List<CountByDate>();
            var days = (to.Date - from.Date).Days;
            for (int i = 0; i <= days; i++)
            {
                var curDate = from.AddDays(i).Date;
                result.Add(new CountByDate()
                {
                    Date = curDate,
                    Count = logs.Where(x => x.LogDate.Date.Equals(curDate)).Select(x => x.UserId).Distinct().Count()
                });
            }

            return result;
        }

        /// <summary>
        /// Возвращает количество запросов расписания на сайте АСУ за период, с разбитием по дням
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public List<CountByDate> GetAsuSchedulerRequestCountByDay(DateTime from, DateTime to)
        {
            // "exec dbo.usp_Adm_LogOnd_Logs 'BlazorSite', 0, 'Успешный вход с кодом%', '20200401', '19000101'";
            var logs = _uow.repoLog.GetLogs("BlazorSite", "Запрос расписания для кода%", from.Date, to.Date);
            if (logs == null)
                return null;

            var result = new List<CountByDate>();
            var days = (to.Date - from.Date).Days;
            for (int i = 0; i <= days; i++)
            {
                var curDate = from.AddDays(i).Date;
                result.Add(new CountByDate()
                {
                    Date = curDate,
                    Count = logs.Count(x => x.LogDate.Date.Equals(curDate))
                });
            }

            return result;
        }

        /// <summary>
        /// Возвращает количество запросов расписания через телеграм за период, с разбитием по дням
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public List<CountByDate> GetTelegramSchedulerRequestCountByDay(DateTime from, DateTime to)
        {
            // "exec dbo.usp_Adm_LogOnd_Logs 'BlazorSite', 0, 'Успешный вход с кодом%', '20200401', '19000101'";
            var logs = _uow.repoLog.GetTelegramShedulerRequestLogs(from.Date, to.Date);
            if (logs == null)
                return null;

            var result = new List<CountByDate>();
            var days = (to.Date - from.Date).Days;
            for (int i = 0; i <= days; i++)
            {
                var curDate = from.AddDays(i).Date;
                result.Add(new CountByDate()
                {
                    Date = curDate,
                    Count = logs.Count(x => x.LogDate.Date.Equals(curDate))
                });
            }

            return result;
        }
    }
}
