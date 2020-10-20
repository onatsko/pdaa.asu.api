using PDAA_cs.Common.DataModels;

namespace pdaa.asu.api.Services.ViewModels
{
    /// <summary>
    /// Резльтат по выборке для Калькулятора ЗНО
    /// </summary>
    public class ZnoCalculatorResult
    {
        public long Id { get; set; }
        public bool IsDel { get; set; }

        public long SpecForYearId { get; set; }

        public ZnoSpec Spec { get; set; }
        public string Exam1Name { get; set; }
        public string Exam2Name { get; set; }
        public string Exam3Name { get; set; }
        public string Exam4Name { get; set; }
        public string Exam5Name { get; set; }
        public string PayTypeName { get; set; }
        public long Exam1Id { get; set; }
        public long Exam2Id { get; set; }
        public long Exam3Id { get; set; }
        public long Exam4Id { get; set; }
        public long Exam5Id { get; set; }
        public bool IsBudget { get; set; }
        public bool IsContract { get; set; }
        public string EducVidName { get; set; }
        public int Cost { get; set; }

        public ZnoCalculatorResult()
        {
            Id = 0;
            IsDel = false;

            //доп.свойства
            SpecForYearId = 0;
            Exam1Name = string.Empty;
            Exam2Name = string.Empty;
            Exam3Name = string.Empty;
            Exam4Name = string.Empty;
            Exam5Name = string.Empty;
            PayTypeName = string.Empty;
            Exam1Id = 0;
            Exam2Id = 0;
            Exam3Id = 0;
            Exam4Id = 0;
            Exam5Id = 0;
            IsBudget = false;
            IsContract = false;
            EducVidName = string.Empty;
            Cost = 0;
        }

        
    }
}
