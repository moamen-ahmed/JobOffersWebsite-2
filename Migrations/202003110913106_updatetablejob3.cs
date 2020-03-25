namespace JobOffersWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetablejob3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Jobs", new[] { "Category_Id" });
            DropColumn("dbo.Jobs", "CategoryId");
            RenameColumn(table: "dbo.Jobs", name: "Category_Id", newName: "CategoryId");
            AlterColumn("dbo.Jobs", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Jobs", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobs", "CategoryId");
            AddForeignKey("dbo.Jobs", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Jobs", new[] { "CategoryId" });
            AlterColumn("dbo.Jobs", "CategoryId", c => c.Int());
            AlterColumn("dbo.Jobs", "CategoryId", c => c.String());
            RenameColumn(table: "dbo.Jobs", name: "CategoryId", newName: "Category_Id");
            AddColumn("dbo.Jobs", "CategoryId", c => c.String());
            CreateIndex("dbo.Jobs", "Category_Id");
            AddForeignKey("dbo.Jobs", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
