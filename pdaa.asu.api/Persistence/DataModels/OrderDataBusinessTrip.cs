using System;

namespace pdaa.asu.api.Persistence.DataModels
{
    public class OrderDataBusinessTrip
    {
        public long pkDocOrderData { get; set; }
        public long fkDocOrder { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public int BusinessTripPeriodDays { get; set; }
        public string TripCostsTypeName { get; set; }
        public string Country1City1 { get; set; }

        public string Organisation1 { get; set; }
        public string Goal1 { get; set; }
        public string DocNameFull { get; set; }
    }
}
