using System;
using System.Collections.Generic;

namespace NetTrader.TradingIndicator.Models
{
    public class DateDoubleSerie : IIndicatorSerie
    {
        public Dictionary<DateTime, double?> Values { get; set; }

        public DateDoubleSerie()
        {
            Values = new Dictionary<DateTime, double?>();
        }
    }
}
