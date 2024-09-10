using System.Text.Json.Serialization;
using iRacingSdkWrapper.Utilities;

namespace iRacingSdkWrapper.JsonModels
{
    public class WeekendOptions
    {
        public int NumStarters { get; set; }
        public string StartingGrid { get; set; }
        public string QualifyScoring { get; set; }
        public string CourseCautions { get; set; }
        public int StandingStart { get; set; }
        public int ShortParadeLap { get; set; }
        public string Restarts { get; set; }
        public string WeatherType { get; set; }
        public string Skies { get; set; }
        public string WindDirection { get; set; }

        [JsonConverter(typeof(JsonNumericConverter))]
        public double WindSpeed { get; set; }

        [JsonConverter(typeof(JsonNumericConverter))]
        public double WeatherTemp { get; set; }

        [JsonConverter(typeof(JsonNumericConverter))]
        public double RelativeHumidity { get; set; }

        [JsonConverter(typeof(JsonNumericConverter))]
        public double FogLevel { get; set; }
        public string TimeOfDay { get; set; }
        public string Date { get; set; }
        public int EarthRotationSpeedupFactor { get; set; }
        public int Unofficial { get; set; }
        public string CommercialMode { get; set; }
        public string NightMode { get; set; }
        public int IsFixedSetup { get; set; }
        public string StrictLapsChecking { get; set; }
        public int HasOpenRegistration { get; set; }
        public int HardcoreLevel { get; set; }
        public int NumJokerLaps { get; set; }
        public string IncidentLimit { get; set; }
        public string FastRepairsLimit { get; set; }
        public int GreenWhiteCheckeredLimit { get; set; }
    }
}