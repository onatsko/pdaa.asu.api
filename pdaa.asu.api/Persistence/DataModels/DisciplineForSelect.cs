namespace pdaa.asu.api.Persistence.DataModels
{
    public class DisciplineForSelect
    {
        public long IdDisciplines_jrn { get; set; }
        public long IdEducPlanSpec { get; set; }
        public long IdDisciplines { get; set; }
        public string DisciplinesName { get; set; }
        public int DisciplinesDiffSelectStudCountMax { get; set; }
        public int DisciplinesDiffSelectStudCountSelect { get; set; }
        public int DisciplinesDiffSelectStudCountSelectFirstRrowNum { get; set; }
        public bool IsLock { get; set; } //Залочена дисциплина
        public bool chkLock { get; set; } //Залочена вся ветка (все дисциплины ветки)
    }
}
