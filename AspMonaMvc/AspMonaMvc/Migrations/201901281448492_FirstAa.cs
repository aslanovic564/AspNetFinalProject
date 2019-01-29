namespace AspMonaMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstAa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LatestNewsContents", "HomePageChange_Id", c => c.Int());
            CreateIndex("dbo.LatestNewsContents", "HomePageChange_Id");
            AddForeignKey("dbo.LatestNewsContents", "HomePageChange_Id", "dbo.HomePageChanges", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LatestNewsContents", "HomePageChange_Id", "dbo.HomePageChanges");
            DropIndex("dbo.LatestNewsContents", new[] { "HomePageChange_Id" });
            DropColumn("dbo.LatestNewsContents", "HomePageChange_Id");
        }
    }
}
