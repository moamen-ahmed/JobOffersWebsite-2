namespace JobOffersWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedatatypeOfCategoryName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.Int(nullable: false));
        }
    }
}
