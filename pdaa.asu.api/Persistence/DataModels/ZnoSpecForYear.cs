namespace PDAA_cs.Common.DataModels
{
    /// <summary>
    /// Специальность для вступающих абитуриентов
    /// </summary>
    public class ZnoSpecForYear
    {
        public long Id { get; set; }
        public bool IsDel { get; set; }

        public long SpecId { get; set; }
        public string SpecCode { get; set; }
        public string SpecName { get; set; }
        public string EducProgram { get; set; }

        public ZnoSpecForYear()
        {
            Id = 0;
            IsDel = false;

            //доп.свойства
            SpecId = 0;
            SpecCode = "";
            SpecName = "";
            EducProgram = "";
        }

        protected bool Equals(ZnoSpecForYear other)
        {
            return Id == other.Id && IsDel == other.IsDel && SpecCode == other.SpecCode && SpecName == other.SpecName && EducProgram == other.EducProgram;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ZnoSpecForYear) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ IsDel.GetHashCode();
                hashCode = (hashCode * 397) ^ (SpecCode != null ? SpecCode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SpecName != null ? SpecName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (EducProgram != null ? EducProgram.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
