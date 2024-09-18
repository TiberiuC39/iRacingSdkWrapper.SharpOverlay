using iRacingSdkWrapper.Utilities;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace iRacingSdkWrapper.JsonModels
{
    public class PlayerRacer
    {
        public int DriverCarIdx { get; set; }
        public int DriverUserID { get; set; }
        public int PaceCarIdx { get; set; }
        public float DriverHeadPosX { get; set; }
        public float DriverHeadPosY { get; set; }
        public float DriverHeadPosZ { get; set; }
        public int DriverCarIsElectric { get; set; }
        public float DriverCarIdleRPM { get; set; }
        public float DriverCarRedLine { get; set; }
        public int DriverCarEngCylinderCount { get; set; }

        [JsonConverter(typeof(JsonNumericConverter))]
        public double DriverCarFuelKgPerLtr { get; set; }

        [JsonConverter(typeof(JsonNumericConverter))]
        public double DriverCarFuelMaxLtr { get; set; }

        [JsonConverter(typeof(JsonNumericConverter))]
        public double DriverCarMaxFuelPct { get; set; }
        public int DriverCarGearNumForward { get; set; }
        public int DriverCarGearNeutral { get; set; }
        public int DriverCarGearReverse { get; set; }
        public float DriverCarSLFirstRPM { get; set; }
        public float DriverCarSLShiftRPM { get; set; }
        public float DriverCarSLLastRPM { get; set; }
        public float DriverCarSLBlinkRPM { get; set; }
        public string DriverCarVersion { get; set; }
        public float? DriverPitTrkPct { get; set; }
        public float DriverCarEstLapTime { get; set; }
        public string DriverSetupName { get; set; }
        public int DriverSetupIsModified { get; set; }
        public string DriverSetupLoadTypeName { get; set; }
        public int DriverSetupPassedTech { get; set; }
        public int DriverIncidentCount { get; set; }

        public List<Racer> Drivers { get; set; }
    }
}