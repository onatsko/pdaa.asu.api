namespace pdaa.asu.api.Persistence.DataModels
{
    public class DisciplineSelected
    {
        public int RowNumSelect { get; set; }
        public long IdDisciplinesDiffSelectJrn { get; set; }
        public int RowNum { get; set; }
        public long IdDisciplinesJrn { get; set; }
        public long IdMoving { get; set; }
        public long IdKadr { get; set; }
        public bool IsAdminGranted { get; set; }
        public string AllKadrName { get; set; }
        public string DisciplinesName { get; set; }
        public int SemesterEduc { get; set; }
        public string EducPlanSpecName { get; set; }
        public string GrupNameAutoAll { get; set; }
        public int DisciplinesDiffSelectStudCountMax { get; set; }
        public int DisciplinesDiffSelectStudCountSelect { get; set; }
        public bool IsLock { get; set; } //Залочена дисциплина
        public bool chkLock { get; set; } //Залочена вся ветка (все дисциплины ветки)
    }
}
