using System.Text.Json.Serialization;

namespace iRacingSdkWrapper.JsonModels
{
    public class Sector
    {
        [JsonPropertyName("SectorNum")]
        public int Num { get; set; }
        [JsonPropertyName("SectorStartPct")]
        public double StartPct { get; set; }
    }
}
