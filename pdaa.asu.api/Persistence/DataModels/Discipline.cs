namespace pdaa.asu.api.Persistence.DataModels
{
    public class Discipline
    {
        public long IdDisciplines { get; set; }
        public string DisciplinesName { get; set; }
        public string DisciplinesNameEng { get; set; }
        public string DisciplinesShortName { get; set; }
        public bool chkNoUs { get; set; }
        public bool chkInterKaf { get; set; }
        public long IdKategoryType { get; set; }
        public string Prim { get; set; }
        public string KafName { get; set; }
        public bool IsDel { get; set; }
        public long IdAspirantType { get; set; }
        public long IdKafAdditionalDekType { get; set; }
    }
}
