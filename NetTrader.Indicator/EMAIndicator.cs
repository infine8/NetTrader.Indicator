﻿using System.Collections.Generic;
using NetTrader.Indicator.Models;

namespace NetTrader.Indicator
{
    /// <summary>
    /// Exponential Moving Average
    /// </summary>
    public class EMAIndicator : IndicatorCalculatorBase<DateDoubleSerie>
    {
        protected override List<Ohlc> OhlcList { get; set; }
        protected int Period = 10;
        protected bool Wilder = false;

        public EMAIndicator()
        { 
        
        }

        public EMAIndicator(int period, bool wilder)
        {
            this.Period = period;
            this.Wilder = wilder;
        }

        /// <summary>
        /// SMA: 10 period sum / 10 
        /// Multiplier: (2 / (Time periods + 1) ) = (2 / (10 + 1) ) = 0.1818 (18.18%)
        /// EMA: {Close - EMA(previous day)} x multiplier + EMA(previous day). 
        /// for Wilder parameter details: http://www.inside-r.org/packages/cran/TTR/docs/GD
        /// </summary>
        /// <see cref="http://stockcharts.com/school/doku.php?id=chart_school:technical_indicators:moving_averages"/>
        /// <returns></returns>
        public override DateDoubleSerie Calculate()
        {
            // karşılaştırma için tutarlar ezilebilir. Bağlantı: http://stockcharts.com/school/doku.php?id=chart_school:technical_indicators:moving_averages
            //OhlcList[0].Close = 22.27;
            //OhlcList[1].Close = 22.19;
            //OhlcList[2].Close = 22.08;
            //OhlcList[3].Close = 22.17;
            //OhlcList[4].Close = 22.18;
            //OhlcList[5].Close = 22.13;
            //OhlcList[6].Close = 22.23;
            //OhlcList[7].Close = 22.43;
            //OhlcList[8].Close = 22.24;
            //OhlcList[9].Close = 22.29;
            //OhlcList[10].Close = 22.15;
            //OhlcList[11].Close = 22.39;
            //OhlcList[12].Close = 22.38;
            //OhlcList[13].Close = 22.61;
            //OhlcList[14].Close = 23.36;

            var emaSerie = new DateDoubleSerie();
            var multiplier = !this.Wilder ? (2.0 / (double)(Period + 1)) : (1.0 / (double)Period);

            for (int i = 0; i < OhlcList.Count; i++)
            {
                var item = OhlcList[i];

                if (i >= Period - 1)
                {
                    var prevItem = OhlcList[i - 1];
                    var close = OhlcList[i].Close;
                    var emaPrev = 0.0;
                    if (emaSerie.Values[prevItem.Date].HasValue)
                    {
                        emaPrev = emaSerie.Values[prevItem.Date].Value;
                        var ema = (close - emaPrev) * multiplier + emaPrev;//(close * multiplier) + (emaPrev * (1 - multiplier));
                        emaSerie.Values.Add(item.Date, ema);
                    }
                    else
                    {
                        double sum = 0;
                        for (int j = i; j >= i - (Period - 1); j--)
                        {
                            sum += OhlcList[j].Close;
                        }
                        var ema = sum / Period;
                        emaSerie.Values.Add(item.Date, ema);
                    }
                }
                else
                {
                    emaSerie.Values.Add(item.Date, null);
                }
            }

            return emaSerie;
        }
    }
}
