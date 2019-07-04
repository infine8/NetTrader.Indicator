using System.Collections.Generic;

namespace NetTrader.TradingIndicator
{
    public abstract class IndicatorCalculatorBase<T>
    {
        protected abstract List<Ohlc> OhlcList { get; set; }

        public virtual void Load(List<Ohlc> ohlcList)
        {
            this.OhlcList = ohlcList;
        }

        public abstract T Calculate();
    }
}
