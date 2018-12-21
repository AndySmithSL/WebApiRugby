using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class Match
    {
        public Match()
        {
            MatchOfficial = new HashSet<MatchOfficial>();
            MatchTeam = new HashSet<MatchTeam>();
        }

        public int MatchId { get; set; }
        public DateTime Date { get; set; }
        public int StadiumId { get; set; }
        public int? Attendance { get; set; }
        public int SeasonId { get; set; }
        public int CompetitionId { get; set; }

        public Competition Competition { get; set; }
        public Season Season { get; set; }
        public Stadium Stadium { get; set; }
        public ICollection<MatchOfficial> MatchOfficial { get; set; }
        public ICollection<MatchTeam> MatchTeam { get; set; }
    }
}
