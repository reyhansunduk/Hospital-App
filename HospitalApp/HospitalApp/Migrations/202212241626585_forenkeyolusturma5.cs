namespace HospitalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forenkeyolusturma5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Birthday", c => c.DateTime(nullable: false));
            AddColumn("dbo.PatientRegistrations", "DateHour", c => c.DateTime(nullable: false));
            DropColumn("dbo.PatientRegistrations", "Date");
            DropColumn("dbo.PatientRegistrations", "Hour");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PatientRegistrations", "Hour", c => c.DateTime(nullable: false));
            AddColumn("dbo.PatientRegistrations", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.PatientRegistrations", "DateHour");
            DropColumn("dbo.Employees", "Birthday");
        }
    }
}
