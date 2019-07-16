using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTrader.Indicator.Models;

namespace NetTrader.Indicator
{
    /// <summary>
    /// True Range / Average True Range
    /// </summary>
    public class ATRIndicator : IndicatorCalculatorBase<ATRSerie>
    {
        protected override List<Ohlc> OhlcList { get; set; }
        protected int Period = 14;

        public ATRIndicator()
        { 
        
        }

        public ATRIndicator(int period)
        {
            this.Period = period;
        }

        /// <summary>
        /// TrueHigh = Highest of high[0] or close[-1]
        /// TrueLow = Highest of low[0] or close[-1]
        /// TR = TrueHigh - TrueLow
        /// ATR = EMA(TR)
        /// </summary>
        /// <see cref="http://www.fmlabs.com/reference/default.htm?url=TR.htm"/>
        /// <see cref="http://www.fmlabs.com/reference/default.htm?url=ATR.htm"/>
        /// <returns></returns>
        public override ATRSerie Calculate()
        {
            ATRSerie atrSerie = new ATRSerie();
            atrSerie.TrueHigh.Add(default, null);
            atrSerie.TrueLow.Add(default, null);
            atrSerie.TrueRange.Add(default, null);
            atrSerie.ATR.Add(default, null);

            for (int i = 1; i < OhlcList.Count; i++)
            {
                double trueHigh = OhlcList[i].High >= OhlcList[i - 1].Close ? OhlcList[i].High : OhlcList[i - 1].Close;
                atrSerie.TrueHigh.Add(OhlcList[i].Date, trueHigh);
                double trueLow = OhlcList[i].Low <= OhlcList[i - 1].Close ? OhlcList[i].Low : OhlcList[i - 1].Close;
                atrSerie.TrueLow.Add(OhlcList[i].Date, trueLow);
                double trueRange = trueHigh - trueLow;
                atrSerie.TrueRange.Add(OhlcList[i].Date, trueRange);    
            }

            for (int i = 1; i < OhlcList.Count; i++)
            {
                OhlcList[i].Close = atrSerie.TrueRange[OhlcList[i].Date].Value;
            }

            EMAIndicator emaIndicator = new EMAIndicator(Period, true);
            emaIndicator.Load(OhlcList.Skip(1).ToList());
            var atrList = emaIndicator.Calculate().Values;
            foreach (var atr in atrList)
            {
                atrSerie.ATR.Add(atr.Key, atr.Value);
            }

            return atrSerie;
        }
    }
}
