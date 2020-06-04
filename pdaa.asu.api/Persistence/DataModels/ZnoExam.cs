namespace PDAA_cs.Common.DataModels
{
    /// <summary>
    /// Специальность для вступающих абитуриентов
    /// </summary>
    public class ZnoExam
    {
        public long Id { get; set; }
        public bool IsDel { get; set; }

        public string Name { get; set; }


        public ZnoExam()
        {
            Id = 0;
            IsDel = false;

            //доп.свойства
            Name = "";
        }

        protected bool Equals(ZnoExam other)
        {
            return Id == other.Id && IsDel == other.IsDel && Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ZnoExam) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id.GetHashCode();
                hashCode = (hashCode * 397) ^ IsDel.GetHashCode();
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
