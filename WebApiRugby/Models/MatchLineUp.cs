using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class MatchLineUp
    {
        public MatchLineUp()
        {
            MatchPoints = new HashSet<MatchPoints>();
        }

        public int MatchLineUpId { get; set; }
        public int MatchTeamId { get; set; }
        public int MatchPositionId { get; set; }
        public int? PlayerId { get; set; }
        public bool Capped { get; set; }
        public bool Captain { get; set; }

        public MatchPosition MatchPosition { get; set; }
        public MatchTeam MatchTeam { get; set; }
        public Player Player { get; set; }
        public ICollection<MatchPoints> MatchPoints { get; set; }
    }
}
