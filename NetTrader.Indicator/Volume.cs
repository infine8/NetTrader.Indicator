﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTrader.TradingIndicator.Models;

namespace NetTrader.TradingIndicator
{
    public class Volume : IndicatorCalculatorBase<SingleDoubleSerie>
    {
        protected override List<Ohlc> OhlcList { get; set; }

        public override SingleDoubleSerie Calculate()
        {
            SingleDoubleSerie volumeSerie = new SingleDoubleSerie();

            foreach (var item in OhlcList)
            {
                volumeSerie.Values.Add(item.Volume);
            }

            return volumeSerie;
        }
    }
}
