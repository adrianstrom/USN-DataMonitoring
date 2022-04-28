using System;
using System.Collections.Generic;

namespace USN_Persistence
{
    public partial class Sensor
    {
        public Sensor()
        {
            Tags = new HashSet<Tag>();
        }

        public int SensorId { get; set; }
        public string? Type { get; set; }
        public string? SensorName { get; set; }
        public int? SiteId { get; set; }

        public virtual Site? Site { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
