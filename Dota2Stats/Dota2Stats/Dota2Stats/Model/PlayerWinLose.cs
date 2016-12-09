using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2Stats
{
    public class PlayerWinLose
    {
        public double win
        {
            get; set;
        }
        public double lose
        {
            get; set;
        }
        public string WinRateStr
        {
            get
            {
                double winrate = (win / (win + lose)) * 100;
                string winrateStr = string.Format("{0:0.00}", winrate);

                return string.Format("{0}%", winrateStr);
            }
        }
    }
}
