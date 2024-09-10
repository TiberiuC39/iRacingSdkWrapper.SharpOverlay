using iRacingSdkWrapper.JsonModels;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace iRacingSdkWrapper
{
    /// <summary>
    /// Represents a single update of the Session Info YAML and includes parsing capabilities.
    /// </summary>
    public class SessionInfo
    {
        public SessionInfo()
        {
            
        }
        public SessionInfo(string jsonSessionInfo, double time)
        {
            var sessionInfo = JsonSerializer.Deserialize<SessionInfo>(jsonSessionInfo, new JsonSerializerOptions()
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString
            });

            WeekendInfo = sessionInfo.WeekendInfo;
            Sessions = sessionInfo.Sessions;
            Drivers = sessionInfo.Drivers;
            Player = sessionInfo.Player;
            Sectors = sessionInfo.Sectors;

            UpdateTime = time;
            Json = jsonSessionInfo;
        }
        public WeekendInfo WeekendInfo { get; set; }
        public List<Session> Sessions { get; set; }
        public List<Racer> Drivers { get; set; }
        public PlayerRacer Player { get; set; }
        public List<Sector> Sectors { get; set; }

        [JsonIgnore]
        public double UpdateTime { get; set; }
        [JsonIgnore]
        public string Json { get; set; }
    }
}
