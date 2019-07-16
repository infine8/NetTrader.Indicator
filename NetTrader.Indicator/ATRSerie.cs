using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTrader.Indicator.Models;

namespace NetTrader.Indicator
{
    public class ATRSerie : IIndicatorSerie
    {
        public Dictionary<DateTime, double?> TrueHigh { get; }
        public Dictionary<DateTime, double?> TrueLow { get; }
        public Dictionary<DateTime, double?> TrueRange { get; }
        public Dictionary<DateTime, double?> ATR { get; }

        public ATRSerie()
        {
            TrueHigh = new Dictionary<DateTime, double?>();
            TrueLow = new Dictionary<DateTime, double?>();
            TrueRange = new Dictionary<DateTime, double?>();
            ATR = new Dictionary<DateTime, double?>();
        }
    }
}
