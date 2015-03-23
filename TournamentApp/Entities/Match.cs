using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TournamentApp.Entities
{
    public class Match
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ID { get; set; }

        public int Level { get; set; }

        public string Title { get; set; }
        public string Location { get; set; }

        public Competitor CompetitorA { get; set; }
        public Competitor CompetitorB { get; set; }

        public Competitor Victor { get; set; }

        public decimal CompetitorScoreA { get; set; }
        public decimal CompetitorScoreB { get; set; }

        public Match NextMatch { get; set; }
    }
}