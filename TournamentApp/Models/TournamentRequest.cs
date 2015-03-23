using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TournamentApp.Models
{
    public class TournamentRequest
    {
        public string Title { get; set; }

        public int Competitors { get; set; }
    }
}