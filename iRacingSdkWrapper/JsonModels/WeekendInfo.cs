using System.Text.Json.Serialization;
using iRacingSdkWrapper.Utilities;

namespace iRacingSdkWrapper.JsonModels
{
    public class WeekendInfo
    {
        public string TrackName { get; set; }
        public int TrackID { get; set; }

        [JsonConverter(typeof(JsonNumericConverter))]
        public double TrackLength { get; set; }
        [JsonConverter(typeof(JsonNumericConverter))]
        public double TrackLengthOfficial { get; set; }
        public string TrackDisplayName { get; set; }
        public string TrackDisplayShortName { get; set; }
        public string TrackConfigName { get; set; }
        public string TrackCity { get; set; }
        public string TrackCountry { get; set; }
        [JsonConverter(typeof(JsonNumericConverter))]
        public double TrackAltitude { get; set; }
        [JsonConverter(typeof(JsonNumericConverter))]
        public double TrackLatitude { get; set; }
        [JsonConverter(typeof(JsonNumericConverter))]
        public double TrackLongitude { get; set; }
        [JsonConverter(typeof(JsonNumericConverter))]
        public double TrackNorthOffset { get; set; }
        public int TrackNumTurns { get; set; }

        [JsonConverter(typeof(JsonNumericConverter))]
        public double TrackPitSpeedLimit { get; set; }
        public string TrackType { get; set; }
        public string TrackDirection { get; set; }
        public string TrackWeatherType { get; set; }
        public string TrackSkies { get; set; }

        [JsonConverter(typeof(JsonNumericConverter))]
        public double TrackSurfaceTemp { get; set; }
        [JsonConverter(typeof(JsonNumericConverter))]
        public double TrackAirTemp { get; set; }
        [JsonConverter(typeof(JsonNumericConverter))]
        public double TrackAirPressure { get; set; }
        [JsonConverter(typeof(JsonNumericConverter))]
        public double TrackWindVel { get; set; }
        [JsonConverter(typeof(JsonNumericConverter))]
        public double TrackWindDir { get; set; }
        [JsonConverter(typeof(JsonNumericConverter))]
        public double TrackRelativeHumidity { get; set; }
        [JsonConverter(typeof(JsonNumericConverter))]
        public double TrackFogLevel { get; set; }
        [JsonConverter(typeof(JsonNumericConverter))]
        public double TrackPrecipitation { get; set; }
        [JsonConverter(typeof(JsonNumericConverter))]
        public double TrackCleanup { get; set; }
        public int TrackDynamicTrack { get; set; }
        public string TrackVersion { get; set; }
        public int SeriesID { get; set; }
        public int SeasonID { get; set; }
        public int SessionID { get; set; }
        public int SubSessionID { get; set; }
        public int LeagueID { get; set; }
        public int Official { get; set; }
        public int RaceWeek { get; set; }
        public string EventType { get; set; }
        public string Category { get; set; }
        public string SimMode { get; set; }
        public int TeamRacing { get; set; }
        public int MinDrivers { get; set; }
        public int MaxDrivers { get; set; }
        public string DCRuleSet { get; set; }
        public int QualifierMustStartRace { get; set; }
        public int NumCarClasses { get; set; }
        public int NumCarTypes { get; set; }
        public int HeatRacing { get; set; }
        public WeekendOptions WeekendOptions { get; set; }
    }
}