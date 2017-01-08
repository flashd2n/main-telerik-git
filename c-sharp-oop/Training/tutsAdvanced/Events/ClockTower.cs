using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public delegate void ChimeEventHandler(object sender, ClockTowerEventArgs args);

    class ClockTower
    {
        public event ChimeEventHandler Chime;

        public void ChimeFivePM()
        {
            Chime(this, new ClockTowerEventArgs { Time = 1700 });
        }

        public void ChimeSixAM()
        {
            var time = new ClockTowerEventArgs();
            time.Time = 6;
            Chime(this, time);
        }

    }
}
