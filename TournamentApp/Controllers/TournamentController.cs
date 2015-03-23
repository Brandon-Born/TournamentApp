using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TournamentApp.Entities;
using TournamentApp.Models;
using TournamentApp.Repositories;

namespace TournamentApp.Controllers
{
    public class TournamentController : ApiController
    {
        /// <summary>
        /// Get Active Tournaments
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TournamentResponse> Get()
        {
           using(var context = new TournamentContext())
           {
               return context.Tournaments.Where(t => t.Active).Select(t => new TournamentResponse() { Active = t.Active, ID = t.ID, Title = t.Title }).ToList();
           }
        }

        /// <summary>
        /// Get Tournament By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TournamentResponse Get(int id)
        {
            using (var context = new TournamentContext())
            {
                return context.Tournaments.Where(t => t.ID == id).Select(t => new TournamentResponse() { Active = t.Active, ID = t.ID, Title = t.Title, Matches = t.Matches.ToList() }).FirstOrDefault();
            }
        }

        // POST: api/Tournament
        public void Post(TournamentRequest request)
        {
            var tournament = new Tournament();

            tournament.Active = true;
            tournament.Title = request.Title;
            tournament.Matches = new List<Match>();

            if (request.Competitors == 2)
            {
                CreateBrackets(1, tournament.Matches);
            }
            else if (request.Competitors <= 4)
            {
                CreateBrackets(2, tournament.Matches);
            }
            else if (request.Competitors <= 8)
            {
                CreateBrackets(3, tournament.Matches);
            }
            else if (request.Competitors <= 16)
            {
                CreateBrackets(4, tournament.Matches);
            }
            else if (request.Competitors <= 32)
            {
                CreateBrackets(5, tournament.Matches);
            }
            else if (request.Competitors <= 64)
            {
                CreateBrackets(6, tournament.Matches);
            }
            else
            {
                throw new Exception("Too many competitors");
            }

            using (var context = new TournamentContext())
            {
                context.Tournaments.Add(tournament);
                context.SaveChanges();
            }
        }

        // DELETE: api/Tournament/5
        public void Delete(int id)
        {
            using (var context = new TournamentContext())
            {
                var tournament = context.Tournaments.FirstOrDefault(t => t.ID == id);

                context.Tournaments.Remove(tournament);
                context.SaveChanges();
            }
        }


        /// <summary>
        /// Recursively Create Brackets
        /// </summary>
        /// <param name="level"></param>
        /// <param name="matches"></param>
        private static void CreateBrackets(int maxLevel, ICollection<Match> matches, int currentLevel = 1)
        {

            if (currentLevel == 1)
            {
                matches.Add(new Match() { Level = currentLevel });
            }
            else
            {
                var newMatches = new List<Match>();

                foreach (var match in matches.Where(m => m.Level == (currentLevel - 1)))
                {
                    newMatches.Add(new Match() { NextMatch = match, Level = currentLevel });
                    newMatches.Add(new Match() { NextMatch = match, Level = currentLevel });
                }

                foreach (var match in newMatches)
                {
                    matches.Add(match);
                }
            }

            if (maxLevel != currentLevel)
            {
                CreateBrackets(maxLevel, matches, ++currentLevel);
            }
        }
    }
}
