﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTrader.Indicator.Models;

namespace NetTrader.Indicator
{
    public class SingleIntSerie : IIndicatorSerie
    {
        public List<int?> Values { get; set; }

        public SingleIntSerie()
        {
            Values = new List<int?>();
        }
    }
}
