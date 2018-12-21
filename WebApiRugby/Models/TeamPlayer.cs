using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class TeamPlayer
    {
        public int TeamPlayerId { get; set; }
        public int PlayerId { get; set; }
        public int TeamId { get; set; }

        public Player Player { get; set; }
        public Team Team { get; set; }
    }
}
