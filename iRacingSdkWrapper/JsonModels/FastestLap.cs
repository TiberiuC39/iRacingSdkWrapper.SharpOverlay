using System.Text.Json.Serialization;

namespace iRacingSdkWrapper.JsonModels
{
    public class FastestLap
    {
        public int CarIdx { get; set; }

        [JsonPropertyName("FastestLap")]
        public int FastestLapNumber { get; set; }
        public float FastestTime { get; set; }
    }
}