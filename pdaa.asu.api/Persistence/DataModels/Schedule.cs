using System;
using System.Collections.Generic;

namespace pdaa.asu.api.Persistence.DataModels
{
    public class Schedule
    {
        public long KadrPK { get; set; }
        public string KadrFullName { get; set; }
        public bool IsTeacher { get; set; }
        public bool IsStud { get; set; }
        public int weekNum { get; set; }
        public DateTime weekFrom { get; set; }
        public DateTime weekTo { get; set; }
        public List<ScheduleData> ScheduleDatas { get; set; }

        public string ErrorDescription { get; set; }

        public Schedule()
        {
            KadrPK = 0;
            KadrFullName = String.Empty;
            IsStud = false;
            IsTeacher = false;
            ScheduleDatas = new List<ScheduleData>();

            ErrorDescription = String.Empty;
        }
    }
}
