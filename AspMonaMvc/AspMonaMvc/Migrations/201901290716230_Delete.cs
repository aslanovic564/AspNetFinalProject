namespace AspMonaMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Delete : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ModelCategories", "CategoryName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ModelCategories", "CategoryName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
