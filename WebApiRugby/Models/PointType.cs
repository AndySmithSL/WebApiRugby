using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class PointType
    {
        public PointType()
        {
            MatchPoints = new HashSet<MatchPoints>();
            PenaltyTry = new HashSet<PenaltyTry>();
            SeasonPoints = new HashSet<SeasonPoints>();
        }

        public int PointTypeId { get; set; }
        public string Type { get; set; }

        public ICollection<MatchPoints> MatchPoints { get; set; }
        public ICollection<PenaltyTry> PenaltyTry { get; set; }
        public ICollection<SeasonPoints> SeasonPoints { get; set; }
    }
}
