namespace USN_Persistence
{
    public partial class Site
    {
        public Site()
        {
            Sensors = new HashSet<Sensor>();
        }

        public int SiteId { get; set; }
        public string? SiteName { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Sensor> Sensors { get; set; }
    }
}
