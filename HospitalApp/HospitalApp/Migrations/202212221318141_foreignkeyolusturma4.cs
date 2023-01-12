namespace HospitalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkeyolusturma4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "PatientId", "dbo.Patients");
            DropIndex("dbo.Rooms", new[] { "PatientId" });
            AddColumn("dbo.Patients", "RoomId", c => c.Int(nullable: false));
            CreateIndex("dbo.Patients", "RoomId");
            AddForeignKey("dbo.Patients", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
            DropColumn("dbo.Rooms", "PatientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "PatientId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Patients", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Patients", new[] { "RoomId" });
            DropColumn("dbo.Patients", "RoomId");
            CreateIndex("dbo.Rooms", "PatientId");
            AddForeignKey("dbo.Rooms", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
        }
    }
}
