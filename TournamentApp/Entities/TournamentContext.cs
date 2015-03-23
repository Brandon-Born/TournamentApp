namespace TournamentApp.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using TournamentApp.Entities;

    public class TournamentContext : DbContext
    {
        // Your context has been configured to use a 'TournamentContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TournamentApp.Repositories.TournamentContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TournamentContext' 
        // connection string in the application configuration file.
        public TournamentContext()
            : base("name=TournamentContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Competitor> Competitors { get; set; }
    }
}