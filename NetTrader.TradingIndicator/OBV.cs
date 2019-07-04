using System.Collections.Generic;
using System.Linq;
using NetTrader.TradingIndicator.Models;

namespace NetTrader.TradingIndicator
{
    /// <summary>
    /// On Balance Volume (OBV)
    /// </summary>
    public class OBV : IndicatorCalculatorBase<DateDoubleSerie>
    {
        protected override List<Ohlc> OhlcList { get; set; }

        /// <summary>
        /// If today’s close is greater than yesterday’s close then:
        /// OBV(i) = OBV(i-1)+VOLUME(i)
        /// If today’s close is less than yesterday’s close then:
        /// OBV(i) = OBV(i-1)-VOLUME(i)
        /// If today’s close is equal to yesterday’s close then:
        /// OBV(i) = OBV(i-1)
        /// </summary>
        /// <see cref="http://ta.mql4.com/indicators/volumes/on_balance_volume"/>
        /// <returns></returns>
        public override DateDoubleSerie Calculate()
        {
            var obvSerie = new DateDoubleSerie();
            obvSerie.Values.Add(OhlcList[0].Date, OhlcList[0].Volume);

            for (var i = 1; i < OhlcList.Count; i++)
            {
                var item = OhlcList[i];

                var values = obvSerie.Values.Values.Select(x => x ?? 0).ToList();

                var value = 0.0;
                if (item.Close > OhlcList[i - 1].Close)
                {
                    value = values[i - 1] + OhlcList[i].Volume;
                }
                else if (item.Close < OhlcList[i - 1].Close)
                {
                    value = values[i - 1] - OhlcList[i].Volume;
                }
                else if (item.Close == OhlcList[i - 1].Close)
                {
                    value = values[i - 1];
                }

                obvSerie.Values.Add(item.Date, value);
            }

            return obvSerie;
        }
    }
}
