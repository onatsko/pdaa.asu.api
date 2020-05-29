namespace pdaa.asu.api.Persistence.DataModels
{
    public class ScheduleJrn
    {
        public long IdSchedule { get; set; }
        public long IdDiscipinesDistrib { get; set; }
        public int EducYearBegin { get; set; }
        public int? WeekNum { get; set; }
        public long? IdAuditory { get; set; }
        public int? DayOfWeekNum { get; set; }
        public int? LessonNum { get; set; }
        public string Prim { get; set; }
        public bool IsDel { get; set; }
        public long IdScheduleAuditoryBlockType { get; set; }
    }
}
