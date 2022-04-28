using System;
using System.Collections.Generic;

namespace USN_Persistence
{
    public partial class MeasuredValue
    {
        public int MeasuredValueId { get; set; }
        public DateTime? Timestamp { get; set; }
        public int? TagId { get; set; }
        public double? Value { get; set; }
        public string? Quality { get; set; }

        public virtual Tag? Tag { get; set; }
    }
}
