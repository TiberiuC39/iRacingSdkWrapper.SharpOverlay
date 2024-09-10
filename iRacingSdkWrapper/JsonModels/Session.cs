using iRacingSdkWrapper.Utilities;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace iRacingSdkWrapper.JsonModels
{
    public class Session
    {
        public int SessionNum { get; set; }
        public string SessionLaps { get; set; }

        [JsonConverter(typeof(SessionTimeJsonConverter))]
        public double SessionTime { get; set; }
        public int SessionNumLapsToAvg { get; set; }
        public string SessionType { get; set; }
        public string SessionTrackRubberState { get; set; }
        public string SessionName { get; set; }
        public string SessionSubType { get; set; }
        public int SessionSkipped { get; set; }
        public int SessionRunGroupsUsed { get; set; }
        public int SessionEnforceTireCompoundChange { get; set; }

        public List<DriverPosition> ResultsPositions { get; set; }

        public List<FastestLapDTO> ResultsFastestLap { get; set; }
        public double ResultsAverageLapTime { get; set; }
        public int ResultsNumCautionFlags { get; set; }
        public int ResultsNumCautionLaps { get; set; }
        public int ResultsNumLeadChanges { get; set; }
        public int ResultsLapsComplete { get; set; }
        public int ResultsOfficial { get; set; }
    }
}