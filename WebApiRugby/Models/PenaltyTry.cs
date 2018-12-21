using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class PenaltyTry
    {
        public int PenaltyTryId { get; set; }
        public int MatchTeamId { get; set; }
        public int PointTypeId { get; set; }

        public MatchTeam MatchTeam { get; set; }
        public PointType PointType { get; set; }
    }
}
