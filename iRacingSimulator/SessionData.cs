﻿using System.Collections.Generic;
using System.Linq;
using iRacingSdkWrapper;
using iRacingSdkWrapper.Bitfields;
using iRacingSimulator.Drivers;

namespace iRacingSimulator
{
    public class SessionData
    {
        public SessionData()
        {
            this.ClassBestLaps = new Dictionary<int, BestLap>();
        }

        public Track Track { get; set; }
        public string EventType { get; set; }
        public string SessionType { get; set; }
        public int SubsessionId { get; set; }

        public double SessionTime { get; set; }
        public double TimeRemaining { get; set; }
        public int LeaderLap { get; set; }

        public bool TrackCleanup { get; set; }
        public bool DynamicTrack { get; set; }
        public TrackConditions.TrackUsageTypes TrackUsage { get; set; }
        public string TrackUsageText { get; set; }

        public string RaceLaps { get; set; }
        public double RaceTime { get; set; }

        public Dictionary<int, BestLap> ClassBestLaps { get; set; }
        public BestLap OverallBestLap { get; set; }
        
        public SessionFlag Flags { get; set; }
        public SessionStates State { get; set; }

        /// <summary>
        /// Is the checkered flag shown? (e.g. winner has passed the finish, but other drivers may still be racing)
        /// </summary>
        public bool IsCheckered { get; set; }

        /// <summary>
        /// Is the session finished? (e.g. all drivers have finished and session is in cool-down)
        /// </summary>
        public bool IsFinished { get; set; }

        public void Update(SessionInfo info)
        {
            this.Track = Track.FromSessionInfo(info);

            var weekend = info.WeekendInfo;
            this.SubsessionId = weekend.SubSessionID;
            this.EventType = weekend.EventType;

            var session = info.Sessions[Sim.Instance.CurrentSessionNumber ?? info.Sessions.Count - 1];
            this.SessionType = session.SessionType;

            this.TrackUsageText = session.SessionTrackRubberState;
            this.TrackUsage = TrackConditions.TrackUsageFromString(this.TrackUsageText);
            
            this.TrackCleanup = weekend.TrackCleanup == 1; 
            this.DynamicTrack = weekend.TrackDynamicTrack == 1;
            
            this.RaceLaps = session.SessionLaps;
            this.RaceTime = session.SessionTime;
        }


        public void Update(TelemetryInfo telemetry)
        {
            this.SessionTime = telemetry.SessionTime.Value;
            this.TimeRemaining = telemetry.SessionTimeRemain.Value;
            this.Flags = telemetry.SessionFlags.Value;
        }

        public void UpdateState(SessionStates state)
        {
            this.State = state;
            this.IsFinished = state == SessionStates.CoolDown;
            this.IsCheckered = (state == SessionStates.CoolDown || state == SessionStates.Checkered);
        }

        public BestLap UpdateFastestLap(Laptime lap, Driver driver)
        {
            var classId = driver.Car.CarClassId;
            if (!this.ClassBestLaps.ContainsKey(classId))
            {
                this.ClassBestLaps.Add(classId, BestLap.Default);
            }

            if (lap.Value > 0 && this.ClassBestLaps[classId].Laptime.Value > lap.Value)
            {
                var bestlap = new BestLap(lap, driver);
                this.ClassBestLaps[classId] = bestlap;

                this.OverallBestLap =
                    this.ClassBestLaps.Values.Where(l => l.Laptime.Value > 0)
                        .OrderBy(l => l.Laptime.Value)
                        .FirstOrDefault();

                return bestlap;
            }
            return null;
        }

    }
}
