using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class MatchOfficial
    {
        public int MatchOfficialId { get; set; }
        public int MatchId { get; set; }
        public int Referee { get; set; }
        public int TouchJudge1 { get; set; }
        public int TouchJudge2 { get; set; }
        public int Tvofficial { get; set; }

        public Match Match { get; set; }
        public Official RefereeNavigation { get; set; }
        public Official TouchJudge1Navigation { get; set; }
        public Official TouchJudge2Navigation { get; set; }
        public Official TvofficialNavigation { get; set; }
    }
}
