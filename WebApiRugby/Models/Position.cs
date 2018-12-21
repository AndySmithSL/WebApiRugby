using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class Position
    {
        public Position()
        {
            MatchPosition = new HashSet<MatchPosition>();
            Player = new HashSet<Player>();
        }

        public int PositionId { get; set; }
        public string Name { get; set; }

        public ICollection<MatchPosition> MatchPosition { get; set; }
        public ICollection<Player> Player { get; set; }
    }
}
