using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Xabe.FFmpeg.Test
{
    public class ProbeTests
    {
        public ProbeTests()
        {
            Console.WriteLine(GetType().Name);
        }

        [CustomFact]
        public async Task StartWithCsvResultTest()
        {
            string result = await Probe.New()
                 .Start($"-loglevel error -skip_frame nokey -select_streams v:0 -show_entries frame=pkt_pts_time -of csv=print_section=0 {Resources.Mp4}").ConfigureAwait(false);

            IEnumerable<string> values = result.Split('\n')
                               .Where(x => !string.IsNullOrEmpty(x));

            Assert.Equal(3, values.Count());
        }

        [CustomFact]
        public async Task StartWithStdOutputTest()
        {
            string result = await Probe.New()
                                       .Start($"-loglevel error -skip_frame nokey -select_streams v:0 -show_entries frame=pkt_pts_time {Resources.Mp4}").ConfigureAwait(false);

            Assert.True(!string.IsNullOrEmpty(result));
        }
    }
}
