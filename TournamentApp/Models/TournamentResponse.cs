using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TournamentApp.Entities;

namespace TournamentApp.Models
{
    public class TournamentResponse
    {
        public bool Active { get; set; }

        public long ID { get; set; }

        public string Title { get; set; }

        public List<Match> Matches { get; set; }
    }
}