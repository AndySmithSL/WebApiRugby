using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class MatchTeam
    {
        public MatchTeam()
        {
            MatchLineUp = new HashSet<MatchLineUp>();
            PenaltyTry = new HashSet<PenaltyTry>();
        }

        public int MatchTeamId { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }

        public Match Match { get; set; }
        public Team Team { get; set; }
        public ICollection<MatchLineUp> MatchLineUp { get; set; }
        public ICollection<PenaltyTry> PenaltyTry { get; set; }
    }
}
