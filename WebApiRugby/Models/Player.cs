using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class Player
    {
        public Player()
        {
            MatchLineUp = new HashSet<MatchLineUp>();
            TeamPlayer = new HashSet<TeamPlayer>();
        }

        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? SpringbokNo { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public int? CityId { get; set; }
        public int? SchoolId { get; set; }
        public int PositionId { get; set; }
        public bool Deceased { get; set; }
        public string FullName { get; set; }

        public City City { get; set; }
        public Position Position { get; set; }
        public School School { get; set; }
        public ICollection<MatchLineUp> MatchLineUp { get; set; }
        public ICollection<TeamPlayer> TeamPlayer { get; set; }
    }
}
