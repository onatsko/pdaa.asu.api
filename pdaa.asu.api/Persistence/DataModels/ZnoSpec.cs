namespace PDAA_cs.Common.DataModels
{
    /// <summary>
    /// Специальность для вступающих абитуриентов
    /// </summary>
    public class ZnoSpec
    {
        public long Id { get; set; }
        public bool IsDel { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string EducProgram { get; set; }


        public ZnoSpec()
        {
            Id = 0;
            IsDel = false;

            //доп.свойства
            Code = "";
            Name = "";
            EducProgram = "";
        }

        protected bool Equals(ZnoSpec other)
        {
            return Id == other.Id && IsDel == other.IsDel && Code == other.Code && Name == other.Name && EducProgram == other.EducProgram;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ZnoSpec) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ IsDel.GetHashCode();
                hashCode = (hashCode * 397) ^ (Code != null ? Code.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (EducProgram != null ? EducProgram.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
