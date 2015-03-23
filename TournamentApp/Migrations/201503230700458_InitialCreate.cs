namespace TournamentApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Competitors",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Level = c.Int(nullable: false),
                        Title = c.String(),
                        Location = c.String(),
                        CompetitorScoreA = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CompetitorScoreB = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CompetitorA_ID = c.Long(),
                        CompetitorB_ID = c.Long(),
                        NextMatch_ID = c.Long(),
                        Victor_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Competitors", t => t.CompetitorA_ID)
                .ForeignKey("dbo.Competitors", t => t.CompetitorB_ID)
                .ForeignKey("dbo.Matches", t => t.NextMatch_ID)
                .ForeignKey("dbo.Competitors", t => t.Victor_ID)
                .Index(t => t.CompetitorA_ID)
                .Index(t => t.CompetitorB_ID)
                .Index(t => t.NextMatch_ID)
                .Index(t => t.Victor_ID);
            
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "Victor_ID", "dbo.Competitors");
            DropForeignKey("dbo.Matches", "NextMatch_ID", "dbo.Matches");
            DropForeignKey("dbo.Matches", "CompetitorB_ID", "dbo.Competitors");
            DropForeignKey("dbo.Matches", "CompetitorA_ID", "dbo.Competitors");
            DropIndex("dbo.Matches", new[] { "Victor_ID" });
            DropIndex("dbo.Matches", new[] { "NextMatch_ID" });
            DropIndex("dbo.Matches", new[] { "CompetitorB_ID" });
            DropIndex("dbo.Matches", new[] { "CompetitorA_ID" });
            DropTable("dbo.Tournaments");
            DropTable("dbo.Matches");
            DropTable("dbo.Competitors");
        }
    }
}
