using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class Official
    {
        public Official()
        {
            MatchOfficialRefereeNavigation = new HashSet<MatchOfficial>();
            MatchOfficialTouchJudge1Navigation = new HashSet<MatchOfficial>();
            MatchOfficialTouchJudge2Navigation = new HashSet<MatchOfficial>();
            MatchOfficialTvofficialNavigation = new HashSet<MatchOfficial>();
        }

        public int OfficialId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public ICollection<MatchOfficial> MatchOfficialRefereeNavigation { get; set; }
        public ICollection<MatchOfficial> MatchOfficialTouchJudge1Navigation { get; set; }
        public ICollection<MatchOfficial> MatchOfficialTouchJudge2Navigation { get; set; }
        public ICollection<MatchOfficial> MatchOfficialTvofficialNavigation { get; set; }
    }
}
