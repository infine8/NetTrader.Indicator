using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTrader.TradingIndicator;

namespace NetTrader.Indicator.Test
{
    [TestClass]
    public class UnitTest
    {
        public List<Ohlc> OhlcList = new List<Ohlc>();

        public UnitTest()
        {
            Load(Directory.GetCurrentDirectory() + "\\table.csv");
        }

        [TestMethod]
        public void ADL()
        {
            ADL adl = new ADL();
            adl.Load(OhlcList);
            SingleDoubleSerie serie = adl.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.Values.Count > 0);
        }

        [TestMethod]
        public void OBV()
        {
            OBV obv = new OBV();
            obv.Load(OhlcList);
            SingleDoubleSerie serie = obv.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.Values.Count > 0);
        }

        [TestMethod]
        public void SMA()
        {
            SMA sma = new SMA(5);
            sma.Load(OhlcList);
            SingleDoubleSerie serie = sma.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.Values.Count > 0);
        }

        [TestMethod]
        public void EMA()
        {
            EMA ema = new EMA(10, true);
            ema.Load(OhlcList);
            SingleDoubleSerie serie = ema.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.Values.Count > 0);
        }

        [TestMethod]
        public void ROC()
        {
            ROC roc = new ROC(12);
            roc.Load(OhlcList);
            SingleDoubleSerie serie = roc.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.Values.Count > 0);
        }

        [TestMethod]
        public void RSI()
        {
            RSI rsi = new RSI(14);
            rsi.Load(OhlcList);
            RSISerie serie = rsi.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.RS.Count > 0);
            Assert.IsTrue(serie.RSI.Count > 0);
        }

        [TestMethod]
        public void WMA()
        {
            WMA wma = new WMA(10);
            wma.Load(OhlcList);
            SingleDoubleSerie serie = wma.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.Values.Count > 0);
        }

        [TestMethod]
        public void DEMA()
        {
            DEMA dema = new DEMA(5);
            dema.Load(OhlcList);
            SingleDoubleSerie serie = dema.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.Values.Count > 0);
        }

        [TestMethod]
        public void MACD()
        {
            //MACD macd = new MACD();
            MACD macd = new MACD(true); 
            macd.Load(OhlcList);
            MACDSerie serie = macd.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.Signal.Count > 0);
            Assert.IsTrue(serie.MACDLine.Count > 0);
            Assert.IsTrue(serie.MACDHistogram.Count > 0);
        }

        [TestMethod]
        public void Aroon()
        {
            Aroon aroon = new Aroon(5);
            aroon.Load(OhlcList);
            AroonSerie serie = aroon.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.Down.Count > 0);
            Assert.IsTrue(serie.Up.Count > 0);
        }

        [TestMethod]
        public void ATR()
        {
            ATR atr = new ATR();
            atr.Load(OhlcList);
            ATRSerie serie = atr.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.ATR.Count > 0);
            Assert.IsTrue(serie.TrueHigh.Count > 0);
            Assert.IsTrue(serie.TrueLow.Count > 0);
            Assert.IsTrue(serie.TrueRange.Count > 0);
        }

        [TestMethod]
        public void BollingerBand()
        {
            BollingerBand bollingerBand = new BollingerBand();
            bollingerBand.Load(OhlcList);
            BollingerBandSerie serie = bollingerBand.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.BandWidth.Count > 0);
            Assert.IsTrue(serie.BPercent.Count > 0);
            Assert.IsTrue(serie.LowerBand.Count > 0);
            Assert.IsTrue(serie.MidBand.Count > 0);
            Assert.IsTrue(serie.UpperBand.Count > 0);
        }

        [TestMethod]
        public void CCI()
        {
            CCI cci = new CCI();
            cci.Load(OhlcList);
            SingleDoubleSerie serie = cci.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.Values.Count > 0);
        }

        [TestMethod]
        public void CMF()
        {
            CMF cmf = new CMF();
            cmf.Load(OhlcList);
            SingleDoubleSerie serie = cmf.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.Values.Count > 0);
        }

        [TestMethod]
        public void CMO()
        {
            CMO cmo = new CMO();
            cmo.Load(OhlcList);
            IIndicatorSerie serie = cmo.Calculate();
            Assert.IsNotNull(serie);
        }

        [TestMethod]
        public void DPO()
        {
            DPO dpo = new DPO();
            dpo.Load(OhlcList);
            SingleDoubleSerie serie = dpo.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.Values.Count > 0);
        }

        [TestMethod]
        public void Envelope()
        {
            Envelope envelope = new Envelope();
            envelope.Load(OhlcList);
            EnvelopeSerie serie = envelope.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.Lower.Count > 0);
            Assert.IsTrue(serie.Upper.Count > 0);
        }

        [TestMethod]
        public void Momentum()
        {
            Momentum momentum = new Momentum();
            momentum.Load(OhlcList);
            SingleDoubleSerie serie = momentum.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.Values.Count > 0);
        }

        [TestMethod]
        public void Volume()
        {
            Volume volume = new Volume();
            volume.Load(OhlcList);
            SingleDoubleSerie serie = volume.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.Values.Count > 0);
        }

        [TestMethod]
        public void TRIX()
        {
            TRIX trix = new TRIX();
            trix.Load(OhlcList);
            SingleDoubleSerie serie = trix.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.Values.Count > 0);
        }

        [TestMethod]
        public void WPR()
        {
            WPR wpr = new WPR();
            wpr.Load(OhlcList);
            SingleDoubleSerie serie = wpr.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.Values.Count > 0);
        }

        [TestMethod]
        public void ZLEMA()
        {
            ZLEMA zlema = new ZLEMA();
            zlema.Load(OhlcList);
            SingleDoubleSerie serie = zlema.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.Values.Count > 0);
        }

        [TestMethod]
        public void ADX()
        {
            ADX adx = new ADX();
            adx.Load(OhlcList);
            ADXSerie serie = adx.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.ADX.Count > 0);
            Assert.IsTrue(serie.DINegative.Count > 0);
            Assert.IsTrue(serie.DIPositive.Count > 0);
            Assert.IsTrue(serie.DX.Count > 0);
            Assert.IsTrue(serie.TrueRange.Count > 0);
        }

        [TestMethod]
        public void SAR()
        {
            SAR sar = new SAR();
            sar.Load(OhlcList);
            SingleDoubleSerie serie = sar.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.Values.Count > 0);
        }

        [TestMethod]
        public void PVT()
        {
            PVT pvt = new PVT();
            pvt.Load(OhlcList);
            SingleDoubleSerie serie = pvt.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.Values.Count > 0);
        }

        [TestMethod]
        public void VROC()
        {
            VROC vroc = new VROC(25);
            vroc.Load(OhlcList);
            SingleDoubleSerie serie = vroc.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.Values.Count > 0);
        }

        [TestMethod]
        public void Ichimoku()
        {
            // Not sure...
            Ichimoku ichimoku = new Ichimoku();
            ichimoku.Load(OhlcList);
            IchimokuSerie serie = ichimoku.Calculate();

            Assert.IsNotNull(serie);
            Assert.IsTrue(serie.BaseLine.Count > 0);
            Assert.IsTrue(serie.ConversionLine.Count > 0);
            Assert.IsTrue(serie.LaggingSpan.Count > 0);
            Assert.IsTrue(serie.LeadingSpanA.Count > 0);
            Assert.IsTrue(serie.LeadingSpanB.Count > 0);
        }


        public virtual void Load(string path)
        {
            using (CsvReader csv = new CsvReader(new StreamReader(path), true))
            {
                int fieldCount = csv.FieldCount;
                string[] headers = csv.GetFieldHeaders();
                OhlcList = new List<Ohlc>();
                while (csv.ReadNextRecord())
                {
                    Ohlc ohlc = new Ohlc();
                    for (int i = 0; i < fieldCount; i++)
                    {
                        switch (headers[i])
                        {
                            case "Date":
                                ohlc.Date = new DateTime(Int32.Parse(csv[i].Substring(0, 4)), Int32.Parse(csv[i].Substring(5, 2)), Int32.Parse(csv[i].Substring(8, 2)));
                                break;
                            case "Open":
                                ohlc.Open = double.Parse(csv[i], CultureInfo.InvariantCulture);
                                break;
                            case "High":
                                ohlc.High = double.Parse(csv[i], CultureInfo.InvariantCulture);
                                break;
                            case "Low":
                                ohlc.Low = double.Parse(csv[i], CultureInfo.InvariantCulture);
                                break;
                            case "Close":
                                ohlc.Close = double.Parse(csv[i], CultureInfo.InvariantCulture);
                                break;
                            case "Volume":
                                ohlc.Volume = int.Parse(csv[i]);
                                break;
                            case "Adj Close":
                                ohlc.AdjClose = double.Parse(csv[i], CultureInfo.InvariantCulture);
                                break;
                            default:
                                break;
                        }
                    }

                    OhlcList.Add(ohlc);
                }
            }
        }

    }
}
