﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTrader.TradingIndicator.Models;

namespace NetTrader.TradingIndicator
{
    public class BollingerBandSerie : IIndicatorSerie
    {
        public List<double?> LowerBand { get; set; }
        public List<double?> MidBand { get; set; }
        public List<double?> UpperBand { get; set; }
        public List<double?> BandWidth { get; set; }
        public List<double?> BPercent { get; set; }

        public BollingerBandSerie()
        {
            LowerBand = new List<double?>();
            MidBand = new List<double?>();
            UpperBand = new List<double?>();
            BandWidth = new List<double?>();
            BPercent = new List<double?>();
        }
    }
}
