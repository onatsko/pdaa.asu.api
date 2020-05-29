namespace pdaa.asu.api.Persistence.DataModels
{
    public class DiscipinesDistribJrn
    {
        public long IdDiscipinesDistrib { get; set; }
        public long? IdEducPlanSpec { get; set; }
        public long IdDisciplines_jrn { get; set; }
        public long IdAspirant { get; set; }
        public long IdKafAdditionalDek { get; set; }
        public long IdKafAdditional { get; set; }
        public long? IdKafedra { get; set; }
        public int? YearEduc { get; set; }
        public int? SemesterEducYear { get; set; }
        public int? SemesterEduc { get; set; }
        public long? IdKadr { get; set; }
        public long IdMoving { get; set; }
        public long? IdGrup { get; set; }
        public int GrupSub { get; set; }
        public long? IdDiscipinesDistribType { get; set; }
        public double DistribHour { get; set; }
        public bool InThread { get; set; }
        public bool IsDel { get; set; }
        public long IdPosada { get; set; }
        public double Stavka { get; set; }
        public long IdDivision { get; set; }
        public double Oklad { get; set; }
        public bool chkPoohBah { get; set; }
        public bool Ext { get; set; }
    }
}
