using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class Competition
    {
        public Competition()
        {
            Match = new HashSet<Match>();
        }

        public int CompetitionId { get; set; }
        public string Name { get; set; }

        public ICollection<Match> Match { get; set; }
    }
}
