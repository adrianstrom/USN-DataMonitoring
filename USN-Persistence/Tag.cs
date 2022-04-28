using System;
using System.Collections.Generic;

namespace USN_Persistence
{
    public partial class Tag
    {
        public Tag()
        {
            MeasuredValues = new HashSet<MeasuredValue>();
            Sensors = new HashSet<Sensor>();
        }

        public int TagId { get; set; }
        public string? Quantity { get; set; }

        public virtual ICollection<MeasuredValue> MeasuredValues { get; set; }

        public virtual ICollection<Sensor> Sensors { get; set; }
    }
}
