using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class MatchPoints
    {
        public int MatchPointId { get; set; }
        public int PointTypeId { get; set; }
        public int MatchLineUpId { get; set; }

        public MatchLineUp MatchLineUp { get; set; }
        public PointType PointType { get; set; }
    }
}
