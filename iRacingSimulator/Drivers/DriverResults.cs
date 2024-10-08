﻿using System;
using System.Collections.Generic;
using System.Linq;
using iRacingSdkWrapper;

namespace iRacingSimulator.Drivers
{
    /// <summary>
    /// Represents a dictionary of session results for a driver. Contains results for all sessions.
    /// </summary>
    public class DriverResults
    {
        private int _currentSessionNumber;

        public DriverResults(Driver driver)
        {
            _driver = driver;
            _sessions = new Dictionary<int, DriverSessionResults>();
        }

        private readonly Dictionary<int, DriverSessionResults> _sessions;
        /// <summary>
        /// Gets the dictionary of session results for this driver.
        /// </summary>
        public Dictionary<int, DriverSessionResults> Sessions { get { return _sessions; } }

        private readonly Driver _driver;
        /// <summary>
        /// Gets the driver object.
        /// </summary>
        public Driver Driver { get { return _driver; } }

        /// <summary>
        /// Checks if this driver is present in the results for the specified session.
        /// </summary>
        public bool HasResult(int sessionNumber)
        {
            return _sessions.ContainsKey(sessionNumber);
        }

        

        /// <summary>
        /// Gets the session results for this driver for the specified session number, or empty results if he does not appear in the results.
        /// </summary>
        public DriverSessionResults FromSession(int sessionNumber)
        {
            if (this.HasResult(sessionNumber)) return _sessions[sessionNumber];
            return new DriverSessionResults(_driver, sessionNumber);
        }

        /// <summary>
        /// Gets the session results for this driver for the specified session number, or empty results if he does not appear in the results.
        /// </summary>
        public DriverSessionResults this[int sessionNumber]
        {
            get { return this.FromSession(sessionNumber); }
        }

        public DriverSessionResults Current
        {
            get { return this.FromSession(_currentSessionNumber); }
        }
    }

    /// <summary>
    /// Represents the session results for a single driver in a single session.
    /// </summary>
    [Serializable]
    public class DriverSessionResults
    {
        public DriverSessionResults(Driver driver, int sessionNumber)
        {
            _driver = driver;
            _sessionNumber = sessionNumber;

            this.Laps = new LaptimeCollection();
            this.IsEmpty = true;

            this.FakeSectorTimes = new[]
                    {
                        new Sector() {Number = 0, StartPercentage = 0f},
                        new Sector() {Number = 1, StartPercentage = 0.333f},
                        new Sector() {Number = 2, StartPercentage = 0.666f}
                    };
        }

        private readonly Driver _driver;
        public Driver Driver { get { return _driver; } }

        private readonly int _sessionNumber;
        public int SessionNumber { get { return _sessionNumber; } }

        public bool IsEmpty { get; set; }

        public int Position { get; set; }
        public int ClassPosition { get; set; }

        public int Lap { get; set; }
        public Laptime Time { get; set; }

        public int FastestLap { get; set; }
        public Laptime FastestTime { get; set; }
        public Laptime LastTime { get; set; }
        public Laptime AverageTime { get; set; }
        public int LapsLed { get; set; }
        public int LapsComplete { get; set; }
        public int LapsDriven { get; set; }
        
        public LaptimeCollection Laps { get; set; }

        public Sector[] SectorTimes { get; set; }
        public Sector[] FakeSectorTimes { get; set; }

        public string SectorsDisplay
        {
            get
            {
                if (SectorTimes == null || SectorTimes.Length == 0) return "-";
                return string.Join(",  ", SectorTimes.Select(s => s.SectorTime == null || s.SectorTime.Value == 0 ? "0.00" : s.SectorTime.DisplayShort));
            }
        }

        public Sector FakeSector1
        {
            get { return FakeSectorTimes == null || FakeSectorTimes.Length == 0 ? null : FakeSectorTimes[0]; }
        }

        public Sector FakeSector2
        {
            get { return FakeSectorTimes == null || FakeSectorTimes.Length == 0 ? null : FakeSectorTimes[1]; }
        }
        
        public Sector FakeSector3
        {
            get { return FakeSectorTimes == null || FakeSectorTimes.Length == 0 ? null : FakeSectorTimes[2]; }
        }

        public int Incidents { get; set; }
        public string OutReason { get; set; }
        public int OutReasonId { get; set; }
        public bool IsOut { get { return this.OutReasonId != 0; } }
        
    }
}
