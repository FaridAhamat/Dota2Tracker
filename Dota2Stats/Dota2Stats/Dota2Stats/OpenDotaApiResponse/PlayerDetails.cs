using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2Stats
{
    public class MmrEstimate
    {
    }

    public class Profile
    {
    }

    public class PlayerDetails
    {
        public string tracked_until
        {
            get; set;
        }
        public string solo_competitive_rank
        {
            get; set;
        }
        public string competitive_rank
        {
            get; set;
        }
        public MmrEstimate mmr_estimate
        {
            get; set;
        }
        public Profile profile
        {
            get; set;
        }
    }
}
