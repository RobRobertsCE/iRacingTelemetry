using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRacing.SetupLibrary.Composite
{
    public interface ILegendsSetup
    {
        ILegendsTires Tires { get; set; }
        ILegendsChassis Chassis { get; set; }
    }
    public class LegendsSetup : ILegendsSetup
    {
        public ILegendsChassis Chassis
        {
            get; set;
        }

        public ILegendsTires Tires
        {
            get; set;
        }
    }
    public interface ILegendsTires
    {
        SetupTireLeft LF { get; set; }
        SetupTireRight RF { get; set; }
        SetupTireLeft LR { get; set; }
        SetupTireRight RR { get; set; }
    }
    public class LegendsTires: CompositeSetup.CompositeTires, ILegendsTires
    {
     
    }
  
  
    //public class LegendsRightFront : ILegendsRightFront
    //{
    //    public string ColdPressure { get; set; }
    //    public string LastHotPressure { get; set; }
    //    public string LastTempsIMO { get; set; }
    //    public string Stagger { get; set; }
    //    public string TreadRemaining { get; set; }
    //}

    //public interface ILegendsRightRear
    //{
    //    string ColdPressure { get; set; }
    //    string LastHotPressure { get; set; }
    //    string LastTempsIMO { get; set; }
    //    string TreadRemaining { get; set; }
    //    string Stagger { get; set; }
    //}
    //public class LegendsRightRear : ILegendsRightRear
    //{
    //    public string ColdPressure { get; set; }
    //    public string LastHotPressure { get; set; }
    //    public string LastTempsIMO { get; set; }
    //    public string Stagger { get; set; }
    //    public string TreadRemaining { get; set; }
    //}

    public interface ILegendsChassis
    {
        ILegendsChassisFront Front { get; set; }
        ILegendsChassisLeftFront LF { get; set; }
        ILegendsChassisLeftRear LR { get; set; }
        ILegendsChassisRightFront RF { get; set; }
        ILegendsChassisRightRear RR { get; set; }
        ILegendsChassisRear Rear { get; set; }
    }

    public interface ILegendsChassisFront
    {
        string ToeIn { get; set; }
        string SteeringOffset { get; set; }
        string FrontBrakeBias { get; set; }
        string FrontWheelOffset { get; set; }
    }
    public interface ILegendsChassisLeftFront
    {
        string CornerWeight { get; set; }
        string RideHeight { get; set; }
        string SpringRate { get; set; }
        string ShockCollarOffset { get; set; }
        string Camber { get; set; }
        string Caster { get; set; }
    }
    public interface ILegendsChassisLeftRear
    {
        string CornerWeight { get; set; }
        string RideHeight { get; set; }
        string SpringRate { get; set; }
        string ShockCollarOffset { get; set; }
    }   
    public interface ILegendsChassisRightFront
    {
        string CornerWeight { get; set; }
        string RideHeight { get; set; }
        string SpringRate { get; set; }
        string ShockCollarOffset { get; set; }
        string Camber { get; set; }
        string Caster { get; set; }
    }
    public interface ILegendsChassisRightRear
    {
        string CornerWeight { get; set; }
        string RideHeight { get; set; }
        string SpringRate { get; set; }
        string ShockCollarOffset { get; set; }
    }
    public interface ILegendsChassisRear
    {
        string RearEndRatio { get; set; }
        string FuelFillTo { get; set; }
        string CrossWeight { get; set; }
    }
}
