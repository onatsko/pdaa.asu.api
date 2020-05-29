using System;

namespace pdaa.asu.api.Persistence.DataModels
{
    public class LogOnd
    {
        public long Id { get; set; }
        public DateTime LogDate { get; set; }
        public long UserId { get; set; }
        public string TableName { get; set; }
        public long ElementId { get; set; }
        public string WhatDo { get; set; }
        public string ElementBefore { get; set; }
        public string ElementAfter { get; set; }
    }
}
