namespace JobOffersWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetablejob2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Jobs", new[] { "CategoryId" });
            AddColumn("dbo.Jobs", "Category_Id", c => c.Int());
            AlterColumn("dbo.Jobs", "CategoryId", c => c.String());
            CreateIndex("dbo.Jobs", "Category_Id");
            AddForeignKey("dbo.Jobs", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Jobs", new[] { "Category_Id" });
            AlterColumn("dbo.Jobs", "CategoryId", c => c.Int(nullable: false));
            DropColumn("dbo.Jobs", "Category_Id");
            CreateIndex("dbo.Jobs", "CategoryId");
            AddForeignKey("dbo.Jobs", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
