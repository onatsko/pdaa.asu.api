using System;

namespace pdaa.asu.api.Persistence.DataModels
{
    public class ScheduleData
    {
        public long IdSchedule { get; set; }
        public long IdDiscipinesDistrib { get; set; }
        public long IdEducPlanSpec { get; set; }
        public long IdDisciplines { get; set; }
        public long IdKafedra { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string LessonNum { get; set; }
        public string AuditoryNum { get; set; }
        public string DisciplinesName { get; set; }
        public string DisciplinesShortName { get; set; }
        public string DiscipinesDistribTypeShortName { get; set; }
        public string GrupSub { get; set; }
        public string GrupSubName { get; set; }
        public long IdGrup { get; set; } // код группы (если для препода расписание) 
        public long IdKadr { get; set; } // код препода (если для студента)

    }
}
