using ibtParserLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using TestSessionLibrary.Extensions;

namespace TestSessionLibrary
{
    public class TestSessionRunData
    {
        #region properties
        public Guid TestSessionRunDataId { get; set; }
        public Guid TestSessionRunId { get; set; }

        // Lap Data //
        public IList<double> LapTimes { get; set; }
        public int LapCount
        {
            get
            {
                return LapTimes.Count();
            }
        }

        // Tires //
        public RightTire RF { get; set; }
        public RightTire RR { get; set; }
        public LeftTire LF { get; set; }
        public LeftTire LR { get; set; }

        // Calculated Lap Data //
        public double BestLap
        {
            get
            {
                return LapTimes.OrderBy(l => l).FirstOrDefault();
            }
        }
        public double AverageLap
        {
            get
            {
                return LapTimes.Average();
            }
        }
        public double MedianLap
        {
            get
            {
                return LapTimes.Median().GetValueOrDefault();
            }
        }
        /// <summary>
        /// Returns the middle 80% of lap times, excluding the top 10% and bottom 10%
        /// Only works with lap counts >= 5
        /// </summary>
        public IList<double> CoreLaps
        {
            get
            {
                var n = LapTimes.Count();

                if (n < 5)
                    return LapTimes;

                var excludeCount = (int)((n * .2));

                return LapTimes.OrderBy(l => l).Skip(excludeCount).Take(n - (excludeCount * 2)).ToList();
            }
        }
        public double CoreAverageLap
        {
            get
            {
                return CoreLaps.Average();
            }
        }
        public double CoreRange
        {
            get
            {
                var coreLapTimes = CoreLaps;
                return coreLapTimes.Max() - coreLapTimes.Min();
            }
        }
        public double CoreStdDev
        {
            get
            {
                return CoreLaps.StdDev();
            }
        }

        // Calculated Tire Data //
        public double CompositeFrontCoreTemp
        {
            get
            {
                return (RF.CompositeCoreTemp + LF.CompositeCoreTemp) / 2;
            }
        }
        public double CompositeFrontSurfaceTemp
        {
            get
            {
                return (RF.CompositeSufaceTemp + LF.CompositeSufaceTemp) / 2;
            }
        }
        public double CompositeRearCoreTemp
        {
            get
            {
                return (RR.CompositeCoreTemp + LR.CompositeCoreTemp) / 2;
            }
        }
        public double CompositeRearSurfaceTemp
        {
            get
            {
                return (RR.CompositeSufaceTemp + LR.CompositeSufaceTemp) / 2;
            }
        }
        public double CompositeLeftCoreTemp
        {
            get
            {
                return (LR.CompositeCoreTemp + LF.CompositeCoreTemp) / 2;
            }
        }
        public double CompositeLeftSurfaceTemp
        {
            get
            {
                return (LR.CompositeSufaceTemp + LF.CompositeSufaceTemp) / 2;
            }
        }
        public double CompositeRightCoreTemp
        {
            get
            {
                return (RR.CompositeCoreTemp + RF.CompositeCoreTemp) / 2;
            }
        }
        public double CompositeRightSurfaceTemp
        {
            get
            {
                return (RR.CompositeSufaceTemp + RF.CompositeSufaceTemp) / 2;
            }
        }

        public double CompositeFrontToRearCoreTempDelta
        {
            get
            {
                return CompositeFrontCoreTemp - CompositeRearCoreTemp;
            }
        }
        public double CompositeRightToLeftCoreTempDelta
        {
            get
            {
                return CompositeRightCoreTemp - CompositeLeftCoreTemp;
            }
        }

        public double CompositeFrontToRearSurfaceTempDelta
        {
            get
            {
                return CompositeFrontSurfaceTemp - CompositeRearSurfaceTemp;
            }
        }
        public double CompositeRightToLeftSurfaceTempDelta
        {
            get
            {
                return CompositeRightSurfaceTemp - CompositeLeftSurfaceTemp;
            }
        }

        public double CompositeFrontWear
        {
            get
            {
                return (RF.CompositeWear + LF.CompositeWear) / 2;
            }
        }
        public double CompositeRearWear
        {
            get
            {
                return (RR.CompositeWear + LR.CompositeWear) / 2;
            }
        }
        public double CompositeFrontToRearWearDelta
        {
            get
            {
                return CompositeFrontWear - CompositeRearWear;
            }
        }

        public double CompositeLeftWear
        {
            get
            {
                return (LR.CompositeWear + LF.CompositeWear) / 2;
            }
        }
        public double CompositeRightWear
        {
            get
            {
                return (RR.CompositeWear + RF.CompositeWear) / 2;
            }
        }
        public double CompositeRightToLeftWearDelta
        {
            get
            {
                return CompositeRightWear - CompositeLeftWear;
            }
        }
        #endregion

        #region ctor
        public TestSessionRunData(TelemetrySession session, ISetup setup) : this()
        {
            var lapTimes = new Dictionary<int, double>();

            foreach (var lap in session.Laps.Where(l => l.LapNumber > 0))
            {
                var lastValue = 0.0;
                foreach (var lastLapTime in lap.SeriesSingle(TelemetryKeys.LapLastLapTime))
                {
                    if (lastLapTime > 0)
                    {
                        if (lastLapTime != lastValue)
                        {
                            //Console.WriteLine("Lap# {0} LastLapTime {1}", lap.LapNumber, lastLapTime);
                            if (!lapTimes.ContainsKey(lap.LapNumber))
                            {
                                lapTimes.Add(lap.LapNumber, lastLapTime);
                            }
                            else
                            {
                                lapTimes[lap.LapNumber] = lastLapTime;
                            }
                            lastValue = lastLapTime;
                        }
                    }
                }
            }
            foreach (var item in lapTimes)
            {
                //Console.WriteLine("Lap# {0} LastLapTime {1}", item.Key, item.Value);
                this.LapTimes.Add(item.Value);
            }

            this.LF.LapCount = this.LapTimes.Count();
            this.LF.ColdPSI = setup.LFTire.ColdPSI;
            this.LF.HotPSI = setup.LFTire.LastHotPSI;
            this.LF.InsideCoreTemp = setup.LFTire.LastTempI;
            this.LF.MiddleCoreTemp  = setup.LFTire.LastTempM;
            this.LF.OutsideCoreTemp = setup.LFTire.LastTempO;
            this.LF.InsideSurfaceTemp = setup.LFTire.LastTempI;
            this.LF.MiddleSurfaceTemp = setup.LFTire.LastTempM;
            this.LF.OutsideSurfaceTemp = setup.LFTire.LastTempO;
            this.LF.InsideWear = setup.LFTire.TreadRemainingI;
            this.LF.MiddleWear = setup.LFTire.TreadRemainingM;
            this.LF.OutsideWear = setup.LFTire.TreadRemainingO;
            
            this.LR.LapCount = this.LapTimes.Count();
            this.LR.ColdPSI = setup.LRTire.ColdPSI;
            this.LR.HotPSI = setup.LRTire.LastHotPSI;
            this.LR.InsideCoreTemp = setup.LRTire.LastTempI;
            this.LR.MiddleCoreTemp = setup.LRTire.LastTempM;
            this.LR.OutsideCoreTemp = setup.LRTire.LastTempO;
            this.LR.InsideSurfaceTemp = setup.LRTire.LastTempI;
            this.LR.MiddleSurfaceTemp = setup.LRTire.LastTempM;
            this.LR.OutsideSurfaceTemp = setup.LRTire.LastTempO;
            this.LR.InsideWear = setup.LRTire.TreadRemainingI;
            this.LR.MiddleWear = setup.LRTire.TreadRemainingM;
            this.LR.OutsideWear = setup.LRTire.TreadRemainingO;


            this.RF.LapCount = this.LapTimes.Count();
            this.RF.ColdPSI = setup.RFTire.ColdPSI;
            this.RF.HotPSI = setup.RFTire.LastHotPSI;
            this.RF.InsideCoreTemp = setup.RFTire.LastTempI;
            this.RF.MiddleCoreTemp = setup.RFTire.LastTempM;
            this.RF.OutsideCoreTemp = setup.RFTire.LastTempO;
            this.RF.InsideSurfaceTemp = setup.RFTire.LastTempI;
            this.RF.MiddleSurfaceTemp = setup.RFTire.LastTempM;
            this.RF.OutsideSurfaceTemp = setup.RFTire.LastTempO;
            this.RF.InsideWear = setup.RFTire.TreadRemainingI;
            this.RF.MiddleWear = setup.RFTire.TreadRemainingM;
            this.RF.OutsideWear = setup.RFTire.TreadRemainingO;


            this.RR.LapCount = this.LapTimes.Count();
            this.RR.ColdPSI = setup.RRTire.ColdPSI;
            this.RR.HotPSI = setup.RRTire.LastHotPSI;
            this.RR.InsideCoreTemp = setup.RRTire.LastTempI;
            this.RR.MiddleCoreTemp = setup.RRTire.LastTempM;
            this.RR.OutsideCoreTemp = setup.RRTire.LastTempO;
            this.RR.InsideSurfaceTemp = setup.RRTire.LastTempI;
            this.RR.MiddleSurfaceTemp = setup.RRTire.LastTempM;
            this.RR.OutsideSurfaceTemp = setup.RRTire.LastTempO;
            this.RR.InsideWear = setup.RRTire.TreadRemainingI;
            this.RR.MiddleWear = setup.RRTire.TreadRemainingM;
            this.RR.OutsideWear = setup.RRTire.TreadRemainingO;

        }
        public TestSessionRunData()
        {
            LapTimes = new List<double>();
            RF = new RightTire();
            RR = new RightTire();
            LF = new LeftTire();
            LR = new LeftTire();
        }
        #endregion

        #region classes
        public abstract class TireReadings
        {
            public double InsideCoreTemp { get; set; }
            public double MiddleCoreTemp { get; set; }
            public double OutsideCoreTemp { get; set; }

            public double InsideSurfaceTemp { get; set; }
            public double MiddleSurfaceTemp { get; set; }
            public double OutsideSurfaceTemp { get; set; }

            public double InsideWear { get; set; }
            public double MiddleWear { get; set; }
            public double OutsideWear { get; set; }

            public double ColdPSI { get; set; }
            public double HotPSI { get; set; }
            public double DeltaPSI
            {
                get
                {
                    return HotPSI - ColdPSI;
                }
            }
            public double DeltaPSIPerLap
            {
                get
                {
                    return DeltaPSI / LapCount;
                }
            }

            public int LapCount { get; set; }

            public abstract double CompositeSufaceTemp { get; }
            public abstract double CompositeCoreTemp { get; }
            public abstract double CompositeWear { get; }
            public  double CompositeWearPerLap
            {
                get
                {
                    if (CompositeWear == 100)
                        return 0;
                    else
                        return (100 - CompositeWear) / LapCount;
                }
            }
        }

        public class LeftTire : TireReadings
        {
            public override double CompositeSufaceTemp
            {
                get
                {
                    return (OutsideSurfaceTemp + MiddleSurfaceTemp) / 2;
                }
            }
            public override double CompositeCoreTemp
            {
                get
                {
                    return (OutsideCoreTemp + MiddleCoreTemp) / 2;
                }
            }
            public override double CompositeWear
            {
                get
                {
                    return (OutsideWear + MiddleWear) / 2;
                }
            }
        }

        public class RightTire : TireReadings
        {
            public override double CompositeSufaceTemp
            {
                get
                {
                    return (InsideSurfaceTemp + MiddleSurfaceTemp) / 2;
                }
            }
            public override double CompositeCoreTemp
            {
                get
                {
                    return (InsideCoreTemp + MiddleCoreTemp) / 2;
                }
            }
            public override double CompositeWear
            {
                get
                {
                    return (InsideWear + MiddleWear) / 2;
                }
            }
        }
        #endregion
    }
}
