using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class MatchPosition
    {
        public MatchPosition()
        {
            MatchLineUp = new HashSet<MatchLineUp>();
        }

        public int MatchPositionId { get; set; }
        public string Name { get; set; }
        public int PositionId { get; set; }
        public bool? IsForward { get; set; }
        public bool? IsBack { get; set; }
        public bool? IsSubstitute { get; set; }
        public int Number { get; set; }

        public Position Position { get; set; }
        public ICollection<MatchLineUp> MatchLineUp { get; set; }
    }
}
