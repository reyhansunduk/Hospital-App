namespace HospitalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkeyolusturma1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Departments", "CategoryId");
            CreateIndex("dbo.Employees", "DepartmentId");
            CreateIndex("dbo.Employees", "RoomId");
            CreateIndex("dbo.Employees", "CategoryId");
            CreateIndex("dbo.PatientRegistrations", "PatientId");
            CreateIndex("dbo.PatientRegistrations", "EmployeeId");
            CreateIndex("dbo.PatientRegistrations", "ProcedureId");
            CreateIndex("dbo.PatientRegistrations", "UserId");
            CreateIndex("dbo.Patients", "UserId");
            CreateIndex("dbo.Rooms", "PatientId");
            CreateIndex("dbo.Rooms", "DepartmentId");
            CreateIndex("dbo.Users", "CategoryId");
            CreateIndex("dbo.Prescriptions", "ProcedureId");
            CreateIndex("dbo.Prescriptions", "UserId");
            AddForeignKey("dbo.Departments", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: false);
            AddForeignKey("dbo.PatientRegistrations", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientRegistrations", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rooms", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "RoomId", "dbo.Rooms", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Rooms", "PatientId", "dbo.Patients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PatientRegistrations", "UserId", "dbo.Users", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Patients", "UserId", "dbo.Users", "Id", cascadeDelete: false);
            AddForeignKey("dbo.PatientRegistrations", "ProcedureId", "dbo.Procedures", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Prescriptions", "ProcedureId", "dbo.Procedures", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Prescriptions", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prescriptions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Prescriptions", "ProcedureId", "dbo.Procedures");
            DropForeignKey("dbo.PatientRegistrations", "ProcedureId", "dbo.Procedures");
            DropForeignKey("dbo.Patients", "UserId", "dbo.Users");
            DropForeignKey("dbo.PatientRegistrations", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Rooms", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Employees", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.PatientRegistrations", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.PatientRegistrations", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Employees", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Departments", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Prescriptions", new[] { "UserId" });
            DropIndex("dbo.Prescriptions", new[] { "ProcedureId" });
            DropIndex("dbo.Users", new[] { "CategoryId" });
            DropIndex("dbo.Rooms", new[] { "DepartmentId" });
            DropIndex("dbo.Rooms", new[] { "PatientId" });
            DropIndex("dbo.Patients", new[] { "UserId" });
            DropIndex("dbo.PatientRegistrations", new[] { "UserId" });
            DropIndex("dbo.PatientRegistrations", new[] { "ProcedureId" });
            DropIndex("dbo.PatientRegistrations", new[] { "EmployeeId" });
            DropIndex("dbo.PatientRegistrations", new[] { "PatientId" });
            DropIndex("dbo.Employees", new[] { "CategoryId" });
            DropIndex("dbo.Employees", new[] { "RoomId" });
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropIndex("dbo.Departments", new[] { "CategoryId" });
        }
    }
}
