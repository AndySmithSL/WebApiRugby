using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class Season
    {
        public Season()
        {
            Match = new HashSet<Match>();
            SeasonPoints = new HashSet<SeasonPoints>();
        }

        public int SeasonId { get; set; }
        public int Year { get; set; }

        public ICollection<Match> Match { get; set; }
        public ICollection<SeasonPoints> SeasonPoints { get; set; }
    }
}
