namespace HospitalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkeyolusturma3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Departments", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Departments", new[] { "CategoryId" });
            DropColumn("dbo.Departments", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departments", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Departments", "CategoryId");
            AddForeignKey("dbo.Departments", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
