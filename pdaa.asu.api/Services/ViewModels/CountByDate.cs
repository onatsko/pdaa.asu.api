using System;

namespace pdaa.asu.api.Services.ViewModels
{
    public class CountByDate
    {
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }

    public class TwoCountByDate
    {
        public DateTime Date { get; set; }
        public int Count1 { get; set; }
        public int Count2 { get; set; }
    }


}
