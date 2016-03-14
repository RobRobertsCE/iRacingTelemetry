namespace ibtParserLibrary
{
    public enum TelemetryKeys
    {
        // Seconds since session start [s]
        SessionTime,

        // Session number []
        SessionNum,

        // Session state [irsdk_SessionState]
        SessionState,

        // Session ID []
        SessionUniqueID,

        // Seconds left till session ends [s]
        SessionTimeRemain,

        // Laps left till session ends []
        SessionLapsRemain,

        // Driver activated flag []
        DriverMarker,

        // 1=Car on track physics running with player in car []
        IsOnTrack,

        // Average frames per second [fps]
        FrameRate,

        // Percent of available tim bg thread took with a 1 sec avg [%]
        CpuUsageBG,

        // Is the player car on pit road between the cones []
        OnPitRoad,

        // Steering wheel angle [rad]
        SteeringWheelAngle,

        // 0=off throttle to 1=full throttle [%]
        Throttle,

        // 0=brake released to 1=max pedal force [%]
        Brake,

        // 0=disengaged to 1=fully engaged [%]
        Clutch,

        // -1=reverse  0=neutral  1..n=current gear []
        Gear,

        // Engine rpm [revs/min]
        RPM,

        // Lap count []
        Lap,

        // Meters traveled from S/F this lap [m]
        LapDist,

        // Percentage distance around lap [%]
        LapDistPct,

        // Players best lap number []
        LapBestLap,

        // Players best lap time [s]
        LapBestLapTime,

        // Players last lap time [s]
        LapLastLapTime,

        // Estimate of players current lap time as shown in F3 box [s]
        LapCurrentLapTime,

        // Delta time for best lap [s]
        LapDeltaToBestLap,

        // Rate of change of delta time for best lap [s/s]
        LapDeltaToBestLap_DD,

        // Delta time for best lap is valid []
        LapDeltaToBestLap_OK,

        // Delta time for optimal lap [s]
        LapDeltaToOptimalLap,

        // Rate of change of delta time for optimal lap [s/s]
        LapDeltaToOptimalLap_DD,

        // Delta time for optimal lap is valid []
        LapDeltaToOptimalLap_OK,

        // Delta time for session best lap [s]
        LapDeltaToSessionBestLap,

        // Rate of change of delta time for session best lap [s/s]
        LapDeltaToSessionBestLap_DD,

        // Delta time for session best lap is valid []
        LapDeltaToSessionBestLap_OK,

        // Delta time for session optimal lap [s]
        LapDeltaToSessionOptimalLap,

        // Rate of change of delta time for session optimal lap [s/s]
        LapDeltaToSessionOptimalLap_DD,

        // Delta time for session optimal lap is valid []
        LapDeltaToSessionOptimalLap_OK,

        // Delta time for session last lap [s]
        LapDeltaToSessionLastlLap,

        // Rate of change of delta time for session last lap [s/s]
        LapDeltaToSessionLastlLap_DD,

        // Delta time for session last lap is valid []
        LapDeltaToSessionLastlLap_OK,

        // Longitudinal acceleration (including gravity) [m/s^2]
        LongAccel,

        // Lateral acceleration (including gravity) [m/s^2]
        LatAccel,

        // Vertical acceleration (including gravity) [m/s^2]
        VertAccel,

        // Roll rate [rad/s]
        RollRate,

        // Pitch rate [rad/s]
        PitchRate,

        // Yaw rate [rad/s]
        YawRate,

        // GPS vehicle speed [m/s]
        Speed,

        // X velocity [m/s]
        VelocityX,

        // Y velocity [m/s]
        VelocityY,

        // Z velocity [m/s]
        VelocityZ,

        // Yaw orientation [rad]
        Yaw,

        // Pitch orientation [rad]
        Pitch,

        // Roll orientation [rad]
        Roll,

        // Latitude in decimal degrees [deg]
        Lat,

        // Longitude in decimal degrees [deg]
        Lon,

        // Altitude in meters [m]
        Alt,

        // Temperature of track at start/finish line [C]
        TrackTemp,

        // Temperature of air at start/finish line [C]
        AirTemp,

        // Time left for mandatory pit repairs if repairs are active [s]
        PitRepairLeft,

        // Time left for optional repairs if repairs are active [s]
        PitOptRepairLeft,

        // 1=Car on track physics running []
        IsOnTrackCar,

        // Output torque on steering shaft [N*m]
        SteeringWheelTorque,

        // Force feedback % max torque on steering shaft unsigned [%]
        SteeringWheelPctTorque,

        // Force feedback % max torque on steering shaft signed [%]
        SteeringWheelPctTorqueSign,

        // Force feedback % max torque on steering shaft signed stops [%]
        SteeringWheelPctTorqueSignStops,

        // Force feedback % max damping [%]
        SteeringWheelPctDamper,

        // Steering wheel max angle [rad]
        SteeringWheelAngleMax,

        // DEPRECATED use DriverCarSLBlinkRPM instead [%]
        ShiftIndicatorPct,

        // Friction torque applied to gears when shifting or grinding [%]
        ShiftPowerPct,

        // RPM of shifter grinding noise [RPM]
        ShiftGrindRPM,

        // Raw throttle input 0=off throttle to 1=full throttle [%]
        ThrottleRaw,

        // Raw brake input 0=brake released to 1=max pedal force [%]
        BrakeRaw,

        // Bitfield for warning lights [irsdk_EngineWarnings]
        EngineWarnings,

        // Liters of fuel remaining [l]
        FuelLevel,

        // Percent fuel remaining [%]
        FuelLevelPct,

        // In car brake bias adjustment []
        dcBrakeBias,

        // Engine coolant temp [C]
        WaterTemp,

        // Engine coolant level [l]
        WaterLevel,

        // Engine fuel pressure [bar]
        FuelPress,

        // Engine oil temperature [C]
        OilTemp,

        // Engine oil pressure [bar]
        OilPress,

        // Engine oil level [l]
        OilLevel,

        // Engine voltage [V]
        Voltage,

        // Engine manifold pressure [bar]
        ManifoldPress,

        // RR wheel speed [m/s]
        RRspeed,

        // RR tire pressure [kPa]
        RRpressure,

        // RR tire cold pressure  as set in the garage [kPa]
        RRcoldPressure,

        // RR tire left surface temperature [C]
        RRtempL,

        // RR tire middle surface temperature [C]
        RRtempM,

        // RR tire right surface temperature [C]
        RRtempR,

        // RR tire left carcass temperature [C]
        RRtempCL,

        // RR tire middle carcass temperature [C]
        RRtempCM,

        // RR tire right carcass temperature [C]
        RRtempCR,

        // RR tire left percent tread remaining [%]
        RRwearL,

        // RR tire middle percent tread remaining [%]
        RRwearM,

        // RR tire right percent tread remaining [%]
        RRwearR,

        // LR wheel speed [m/s]
        LRspeed,

        // LR tire pressure [kPa]
        LRpressure,

        // LR tire cold pressure  as set in the garage [kPa]
        LRcoldPressure,

        // LR tire left surface temperature [C]
        LRtempL,

        // LR tire middle surface temperature [C]
        LRtempM,

        // LR tire right surface temperature [C]
        LRtempR,

        // LR tire left carcass temperature [C]
        LRtempCL,

        // LR tire middle carcass temperature [C]
        LRtempCM,

        // LR tire right carcass temperature [C]
        LRtempCR,

        // LR tire left percent tread remaining [%]
        LRwearL,

        // LR tire middle percent tread remaining [%]
        LRwearM,

        // LR tire right percent tread remaining [%]
        LRwearR,

        // RF wheel speed [m/s]
        RFspeed,

        // RF tire pressure [kPa]
        RFpressure,

        // RF tire cold pressure  as set in the garage [kPa]
        RFcoldPressure,

        // RF tire left surface temperature [C]
        RFtempL,

        // RF tire middle surface temperature [C]
        RFtempM,

        // RF tire right surface temperature [C]
        RFtempR,

        // RF tire left carcass temperature [C]
        RFtempCL,

        // RF tire middle carcass temperature [C]
        RFtempCM,

        // RF tire right carcass temperature [C]
        RFtempCR,

        // RF tire left percent tread remaining [%]
        RFwearL,

        // RF tire middle percent tread remaining [%]
        RFwearM,

        // RF tire right percent tread remaining [%]
        RFwearR,

        // LF wheel speed [m/s]
        LFspeed,

        // LF tire pressure [kPa]
        LFpressure,

        // LF tire cold pressure  as set in the garage [kPa]
        LFcoldPressure,

        // LF tire left surface temperature [C]
        LFtempL,

        // LF tire middle surface temperature [C]
        LFtempM,

        // LF tire right surface temperature [C]
        LFtempR,

        // LF tire left carcass temperature [C]
        LFtempCL,

        // LF tire middle carcass temperature [C]
        LFtempCM,

        // LF tire right carcass temperature [C]
        LFtempCR,

        // LF tire left percent tread remaining [%]
        LFwearL,

        // LF tire middle percent tread remaining [%]
        LFwearM,

        // LF tire right percent tread remaining [%]
        LFwearR,

        // RR shock deflection [m]
        RRshockDefl,

        // RR shock velocity [m/s]
        RRshockVel,

        // LR shock deflection [m]
        LRshockDefl,

        // LR shock velocity [m/s]
        LRshockVel,

        // RF shock deflection [m]
        RFshockDefl,

        // RF shock velocity [m/s]
        RFshockVel,

        // LF shock deflection [m]
        LFshockDefl,

        // LF shock velocity [m/s]
        LFshockVel,

        // LF ride height [m]
        LFrideHeight,

        // RF ride height [m]
        RFrideHeight,

        // LR ride height [m]
        LRrideHeight,

        // RR ride height [m]
        RRrideHeight

    }
}