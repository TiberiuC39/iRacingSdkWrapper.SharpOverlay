using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iRacingSdkWrapper;

namespace iRacingSimulator.Drivers
{
    public class DriverQualyResults
    {
        public DriverQualyResults(Driver driver)
        {
            _driver = driver;
        }

        private readonly Driver _driver;
        /// <summary>
        /// Gets the driver object.
        /// </summary>
        public Driver Driver { get { return _driver; } }

        public int Position { get; set; }
        public int ClassPosition { get; set; }
        public Laptime Lap { get; set; }        
    }
}
