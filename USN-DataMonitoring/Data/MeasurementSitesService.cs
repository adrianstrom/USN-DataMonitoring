using Microsoft.EntityFrameworkCore;
using USN_Persistence;

namespace USN_DataMonitoring.Data
{
    public class MeasurementSitesService
    {
        private readonly MeasurementSitesContext _context;
        public MeasurementSitesService(MeasurementSitesContext context)
        {
            _context = context;
        }

        public List<Site> GetSites() => _context.Sites.ToList();

        public List<Sensor> GetSensors(int siteId) => _context.Sensors.Where(s => s.SiteId == siteId)
                .Include(s => s.Tags)
                .ThenInclude(s => s.MeasuredValues)
                .ToList();

        public List<Tag> GetAllTags() => _context.Tags.ToList();

        public Tag? GetTag(int tagId) => _context.Tags.FirstOrDefault(x => x.TagId == tagId);

        public double? GetLastMeasuredValueForTag(int tagId) => _context.MeasuredValues.LastOrDefault(v => v.TagId == tagId)?.Value;

        public List<MeasuredValue> GetMeasuredValuesForTag(int tagId, DateTime start, DateTime end) =>
            _context.MeasuredValues.Where(s => s.TagId == tagId && s.Timestamp >= start && s.Timestamp <= end).ToList();
    }
}