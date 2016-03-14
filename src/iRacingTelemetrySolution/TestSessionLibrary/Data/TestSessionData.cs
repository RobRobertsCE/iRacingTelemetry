using iRacing.SetupLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using TestSessionLibrary.Data.Models;

namespace TestSessionLibrary.Data
{
    public class TestSessionData : IDisposable
    {
        #region public
        //public virtual void SaveRun(TestSessionRun run)
        //{
        //    if (Guid.Empty == run.TestSessionRunId)
        //        InsertRun(run);
        //    else
        //        UpdateRun(run);
        //}
        //public virtual TestSessionRun GetRun(Guid id)
        //{
        //    return new TestSessionRun();
        //}
        //public virtual IList<TestSessionRun> GetRuns()
        //{
        //    var runs = new List<TestSessionRun>();           

        //    using (var ctx = new TestSessionDbContext())
        //    {
        //        var runModels = ctx.Runs.ToList();
        //        foreach (var model in runModels)
        //        {
        //            var testSessionRun = new TestSessionRun(model);                   
        //            runs.Add(testSessionRun);
        //        }
        //        return runs;
        //    }
        //}
        //public virtual IList<TestSessionRun> GetRuns(int maxCount)
        //{
        //    var runs = new List<TestSessionRun>();

        //    using (var ctx = new TestSessionDbContext())
        //    {
        //        var runModels = ctx.Runs.Take(maxCount).ToList();
        //        foreach (var model in runModels)
        //        {
        //            var testSessionRun = new TestSessionRun(model);
        //            runs.Add(testSessionRun);
        //        }
        //        return runs;
        //    }
        //}

        public virtual void SaveSkModifiedSetup(ICarSetup setup)
        {
            InsertSkModifiedSetup(setup);
        }
        public virtual void SaveSetup()
        {

        }
        #endregion

        #region protected
        protected virtual void InsertRun(TestSessionRun run)
        {
            using (var ctx = new TestSessionDbContext())
            {
                var model = run.ToNewModel();
                ctx.Runs.Add(model);
                ctx.SaveChanges();
            }
        }
        protected virtual void UpdateRun(TestSessionRun run)
        {
            using (var ctx = new TestSessionDbContext())
            {
                var model = ctx.Runs.FirstOrDefault(m => m.TestSessionRunId == run.TestSessionRunId);
                if (null != model)
                {
                    run.UpdateModel(ref model);
                    ctx.SaveChanges();
                }
                else
                    throw new ArgumentException("Run Not Found");
            }
        }

        protected virtual void InsertSkModifiedSetup(ICarSetup setup)
        {
            using (var ctx = new TestSessionDbContext())
            {
                var setupModel = ToModifiedSetupModel(setup);
                var trackModel = ctx.Tracks.FirstOrDefault(t => t.Name == setup.TrackName);
                if (null == trackModel)
                {
                    trackModel = new TrackModel();
                    trackModel.Name = setup.TrackName;
                    trackModel.TrackNumber = setup.TrackNumber;
                    trackModel.Length = 0;
                    ctx.Tracks.Add(trackModel);
                }
                setupModel.Track = trackModel;

                var carModel = ctx.Cars.FirstOrDefault(t => t.Name == setup.CarName);
                if (null == carModel)
                {
                    carModel = new CarModel();
                    carModel.Name = setup.CarName;
                    carModel.CarNumber = setup.CarNumber;
                    carModel.DisplayName = setup.CarName;
                    carModel.Path = setup.CarName;
                    ctx.Cars.Add(carModel);
                }
                setupModel.Car = carModel;

                ctx.Modifieds.Add(setupModel);
                ctx.SaveChanges();
                setup.SetupId = setupModel.ModifiedSetupId;
            }
        }     
        #endregion

        //#region helper
        //public ModifiedSetupModel ToModifiedSetupModel(SKModifiedSetup setup)
        //{
        //    var model = new ModifiedSetupModel();
        //    UpdateModifiedSetupModel(setup, ref model);
        //    return model;
        //}
        //public void UpdateModifiedSetupModel(SKModifiedSetup setup, ref ModifiedSetupModel model)
        //{
        //    model.Name = setup.Name;
        //    model.TrackName = setup.TrackName;
        //    model.TrackNumber = setup.TrackNumber;
        //    model.CarName = setup.CarName;
        //    model.CarNumber = setup.CarNumber;
        //    model.BallastForward = setup.BallastForward;
        //    model.FrontWeightPercent = setup.FrontWeightPercent;
        //    model.CrossWeightPercent = setup.CrossWeightPercent;
        //    model.ToeIn = setup.ToeIn;
        //    model.SteerRatio = setup.SteerRatio;
        //    model.FtBrakeBias = setup.FtBrakeBias;
        //    model.SwayBarSize = setup.SwayBarSize;
        //    model.SwayBarArm = setup.SwayBarArm;
        //    model.SwayBarLeftClearance = setup.SwayBarLeftClearance;
        //    model.SwayBarLeftAttached = setup.SwayBarLeftAttached;
        //    model.FuelLevel = setup.FuelLevel;
        //    model.FinalGearRatio = setup.FinalGearRatio;
        //    model.TrackBarLeft = setup.RRSuspension.TrackBarHeight;
        //    model.TrackBarRight = setup.LRSuspension.TrackBarHeight;

        //    model.RFCamber = setup.RFSuspension.Camber;
        //    model.RFCaster = setup.RFSuspension.Caster;
        //    model.RFRideHeight = setup.RFSuspension.Height;
        //    model.RFSpringRate = setup.RFSuspension.SpringRate;
        //    model.RFPSICold = setup.RFTire.ColdPSI;
        //    model.RFStaticLoad = setup.RFSuspension.Weight;
        //    model.RFShockCollarOffset = Convert.ToDouble(setup.RFSuspension.ScrewJack);

        //    model.LFCamber = setup.LFSuspension.Camber;
        //    model.LFCaster = setup.LFSuspension.Caster;
        //    model.LFRideHeight = setup.LFSuspension.Height;
        //    model.LFSpringRate = setup.LFSuspension.SpringRate;
        //    model.LFPSICold = setup.LFTire.ColdPSI;
        //    model.LFStaticLoad = setup.LFSuspension.Weight;
        //    model.LFShockCollarOffset = Convert.ToDouble(setup.LFSuspension.ScrewJack);

        //    model.LRRideHeight = setup.LRSuspension.Height;
        //    model.LRSpringRate = setup.LRSuspension.SpringRate;
        //    model.LRPSICold = setup.LRTire.ColdPSI;
        //    model.LRStaticLoad = setup.LRSuspension.Weight;
        //    model.LRShockCollarOffset = Convert.ToDouble(setup.LRSuspension.ScrewJack);

        //    model.RRRideHeight = setup.RRSuspension.Height;
        //    model.RRSpringRate = setup.RRSuspension.SpringRate;
        //    model.RRPSICold = setup.RRTire.ColdPSI;
        //    model.RRStaticLoad = setup.RRSuspension.Weight;
        //    model.RRShockCollarOffset = Convert.ToDouble(setup.RRSuspension.ScrewJack);

        //    model.LFBump = setup.LFSuspension.BumpStiffness;
        //    model.LFRebound = setup.LFSuspension.ReboundStiffness;

        //    model.LRBump = setup.LRSuspension.BumpStiffness;
        //    model.LRRebound = setup.LRSuspension.ReboundStiffness;

        //    model.RFBump = setup.RFSuspension.BumpStiffness;
        //    model.RFRebound = setup.RFSuspension.ReboundStiffness;

        //    model.RRBump = setup.RRSuspension.BumpStiffness;
        //    model.RRRebound = setup.RRSuspension.ReboundStiffness;

        //    model.BallastForward = setup.BallastForward;
        //    model.FrontWeightPercent = setup.FrontWeightPercent;
        //    model.CrossWeightPercent = setup.CrossWeightPercent;
        //    model.ToeIn = setup.ToeIn;
        //    model.SteerRatio = setup.SteerRatio;
        //    model.FtBrakeBias = setup.FtBrakeBias;
        //    model.SwayBarSize = setup.SwayBarSize;
        //    model.SwayBarArm = setup.SwayBarArm;
        //    model.SwayBarLeftClearance = setup.SwayBarLeftClearance;
        //    model.SwayBarLeftAttached = setup.SwayBarLeftAttached;
        //    model.FuelLevel = setup.FuelLevel;
        //    model.FinalGearRatio = setup.FinalGearRatio;
        //    model.Notes = setup.Notes;
        //}
        //#endregion

        #region IDisposable
        public void Dispose()
        {

        }
        #endregion
    }
}
