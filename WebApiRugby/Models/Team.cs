using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class Team
    {
        public Team()
        {
            Coach = new HashSet<Coach>();
            MatchTeam = new HashSet<MatchTeam>();
            TeamCountry = new HashSet<TeamCountry>();
            TeamPlayer = new HashSet<TeamPlayer>();
        }

        public int TeamId { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string SmallName { get; set; }
        public string BadgeUrl { get; set; }

        public ICollection<Coach> Coach { get; set; }
        public ICollection<MatchTeam> MatchTeam { get; set; }
        public ICollection<TeamCountry> TeamCountry { get; set; }
        public ICollection<TeamPlayer> TeamPlayer { get; set; }
    }
}
