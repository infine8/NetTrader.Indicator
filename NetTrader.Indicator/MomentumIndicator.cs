using System.Collections.Generic;
using NetTrader.Indicator.Models;

namespace NetTrader.Indicator
{
    public class MomentumIndicator : IndicatorCalculatorBase<DateDoubleSerie>
    {
        protected override List<Ohlc> OhlcList { get; set; }

        public override DateDoubleSerie Calculate()
        {
            var momentumSerie = new DateDoubleSerie();
            momentumSerie.Values.Add(default, null);

            for (int i = 1; i < OhlcList.Count; i++)
            {
                momentumSerie.Values.Add(OhlcList[i].Date, OhlcList[i].Close - OhlcList[i - 1].Close);    
            }

            return momentumSerie;
        }

        public SingleDoubleSerie Calculate(List<double> values)
        {
            SingleDoubleSerie momentumSerie = new SingleDoubleSerie();
            momentumSerie.Values.Add(null);

            for (int i = 1; i < values.Count; i++)
            {
                momentumSerie.Values.Add(values[i] - values[i - 1]);
            }

            return momentumSerie;
        }
    }
}
