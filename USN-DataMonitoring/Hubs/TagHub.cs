using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;
using USN_Persistence;

namespace USN_DataMonitoring.Hubs
{
    public class TagHub : Hub
    {
        private MeasurementSitesContext _context;

        public TagHub(MeasurementSitesContext context)
        {
            _context = context;
        }

        public async IAsyncEnumerable<double> Counter(int count, int delay, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            for (var i = 0; i < count; i++)
            {
                // Check the cancellation token regularly so that the server will stop
                // producing items if the client disconnects.
                cancellationToken.ThrowIfCancellationRequested();

                var tagId = 1;

                //var lastMeasuredValue = _context.MeasuredValues.LastOrDefault();

                yield return 1;

                // Use the cancellationToken in other APIs that accept cancellation
                // tokens so the cancellation can flow down to them.
                await Task.Delay(delay, cancellationToken);
            }
        }

        //public ChannelReader<MeasuredValue> Counter(int tagId, int delay, CancellationToken cancellationToken)
        //{
        //    var channel = Channel.CreateUnbounded<MeasuredValue>();
        //    Task.Run(async () => await GetTagValue(channel.Writer, tagId, delay, cancellationToken));
        //    return channel.Reader;
        //}

        //private async Task GetTagValue(ChannelWriter<MeasuredValue> writer, int tagId, int delay, CancellationToken cancellationToken)
        //{
        //    var lastMeasuredValue = _context.MeasuredValues.Where(m => m.TagId == tagId)?.LastOrDefault();
        //    await writer.WriteAsync(lastMeasuredValue ?? new MeasuredValue(), cancellationToken);
        //    await Task.Delay(delay, cancellationToken);
        //}
    }
}
