﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iRacingSdkWrapper
{
    public enum TrackSurfaces
    {
        NotInWorld = -1,
        OffTrack,
        InPitStall,
        AproachingPits,
        OnTrack
    }

    public enum SessionStates
    {
        Invalid,
        GetInCar,
        Warmup,
        ParadeLaps,
        Racing,
        Checkered,
        CoolDown
    }

    public enum CarLeftRight
    {
        irsdk_LROff,
        irsdk_LRClear, // no cars around us.
        irsdk_LRCarLeft, // there is a car to our left.
        irsdk_LRCarRight, // there is a car to our right.
        irsdk_LRCarLeftRight, // there are cars on each side.
        irsdk_LR2CarsLeft, // there are two cars to our left.
        irsdk_LR2CarsRight // there are two cars to our right.
    };
}
