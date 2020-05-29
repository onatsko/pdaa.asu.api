using System;

namespace pdaa.asu.api.Persistence.DataModels
{
    public class OrderDataVacation
    {
        public long pkDocOrderData { get; set; }
        public long fkDocOrder { get; set; }
        public long fkParentDocOrderData { get; set; }
        public long fkKadr { get; set; }
        public long idMoving { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime PeriodWorkFrom { get; set; }
        public DateTime PeriodWorkTo { get; set; }
        public long fkDismissalReason { get; set; }
        public DateTime DismissalDate { get; set; }
        public bool chkVacantionSpecial { get; set; }
        public int VacantionDaysSpecial { get; set; }
        public string DocNameFull { get; set; }
        public int OrderDays { get; set; }
        public long fkOrderTypeExt { get; set; } 
        public string OrderTypeExtName { get; set; } 
        public long IdPosada { get; set; } 
        public string PosadaName { get; set; } 
        public DateTime VacantionDateEnd { get; set; } 
        public string VacationSubTypeName { get; set; } 
        public string DocOrderDataComment { get; set; } 
        public bool chkPoohBah { get; set; } 

    }
}
