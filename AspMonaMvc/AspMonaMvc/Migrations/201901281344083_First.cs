namespace AspMonaMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CastingModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CastHeader = c.String(maxLength: 100),
                        CastResumeHeader = c.String(maxLength: 500),
                        ImageContentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ImageContents", t => t.ImageContentId, cascadeDelete: true)
                .Index(t => t.ImageContentId);
            
            CreateTable(
                "dbo.ImageContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrlName = c.String(),
                        MonaTeamModelId = c.Int(nullable: false),
                        LatestNewsContentId = c.Int(nullable: false),
                        ClientsFedbackModelsId = c.Int(nullable: false),
                        ModellsChangeId = c.Int(nullable: false),
                        HomePageChangeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientsFedbackModels", t => t.ClientsFedbackModelsId, cascadeDelete: true)
                .ForeignKey("dbo.HomePageChanges", t => t.HomePageChangeId, cascadeDelete: true)
                .ForeignKey("dbo.LatestNewsContents", t => t.LatestNewsContentId, cascadeDelete: true)
                .ForeignKey("dbo.ModellsChanges", t => t.ModellsChangeId, cascadeDelete: true)
                .ForeignKey("dbo.MonaTeamModels", t => t.MonaTeamModelId, cascadeDelete: true)
                .Index(t => t.MonaTeamModelId)
                .Index(t => t.LatestNewsContentId)
                .Index(t => t.ClientsFedbackModelsId)
                .Index(t => t.ModellsChangeId)
                .Index(t => t.HomePageChangeId);
            
            CreateTable(
                "dbo.ClientsFedbackModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientName = c.String(),
                        ClientStatus = c.String(),
                        Descriptions = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HomePageChanges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Facebook = c.String(),
                        Tviter = c.String(),
                        Pinterest = c.String(),
                        Instagram = c.String(),
                        Youtube = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LatestNewsContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NewsImageUrl = c.String(),
                        ImageDescription = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModellsChanges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelFullName = c.String(),
                        FigurStatus = c.String(),
                        ModelCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ModelCategories", t => t.ModelCategoryId, cascadeDelete: true)
                .Index(t => t.ModelCategoryId);
            
            CreateTable(
                "dbo.ModelCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MonaTeamModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamImagesDescription = c.String(nullable: false),
                        NameTeam = c.String(nullable: false),
                        statusTeam = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactDetalis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactDetaliss = c.String(nullable: false, maxLength: 200),
                        Reception = c.String(),
                        Booking = c.String(),
                        President = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactUserModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 15),
                        UserEmail = c.String(nullable: false, maxLength: 30),
                        UserResume = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Socials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Facebook = c.String(),
                        Tviter = c.String(),
                        Pinterest = c.String(),
                        Instagram = c.String(),
                        Youtube = c.String(),
                        ModellsChangeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ModellsChanges", t => t.ModellsChangeId, cascadeDelete: true)
                .Index(t => t.ModellsChangeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Socials", "ModellsChangeId", "dbo.ModellsChanges");
            DropForeignKey("dbo.CastingModels", "ImageContentId", "dbo.ImageContents");
            DropForeignKey("dbo.ImageContents", "MonaTeamModelId", "dbo.MonaTeamModels");
            DropForeignKey("dbo.ImageContents", "ModellsChangeId", "dbo.ModellsChanges");
            DropForeignKey("dbo.ModellsChanges", "ModelCategoryId", "dbo.ModelCategories");
            DropForeignKey("dbo.ImageContents", "LatestNewsContentId", "dbo.LatestNewsContents");
            DropForeignKey("dbo.ImageContents", "HomePageChangeId", "dbo.HomePageChanges");
            DropForeignKey("dbo.ImageContents", "ClientsFedbackModelsId", "dbo.ClientsFedbackModels");
            DropIndex("dbo.Socials", new[] { "ModellsChangeId" });
            DropIndex("dbo.ModellsChanges", new[] { "ModelCategoryId" });
            DropIndex("dbo.ImageContents", new[] { "HomePageChangeId" });
            DropIndex("dbo.ImageContents", new[] { "ModellsChangeId" });
            DropIndex("dbo.ImageContents", new[] { "ClientsFedbackModelsId" });
            DropIndex("dbo.ImageContents", new[] { "LatestNewsContentId" });
            DropIndex("dbo.ImageContents", new[] { "MonaTeamModelId" });
            DropIndex("dbo.CastingModels", new[] { "ImageContentId" });
            DropTable("dbo.Socials");
            DropTable("dbo.ContactUserModels");
            DropTable("dbo.ContactDetalis");
            DropTable("dbo.MonaTeamModels");
            DropTable("dbo.ModelCategories");
            DropTable("dbo.ModellsChanges");
            DropTable("dbo.LatestNewsContents");
            DropTable("dbo.HomePageChanges");
            DropTable("dbo.ClientsFedbackModels");
            DropTable("dbo.ImageContents");
            DropTable("dbo.CastingModels");
        }
    }
}
