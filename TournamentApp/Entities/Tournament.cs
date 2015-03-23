using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TournamentApp.Entities
{
    public class Tournament
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ID { get; set; }

        public string Title { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
    }
}