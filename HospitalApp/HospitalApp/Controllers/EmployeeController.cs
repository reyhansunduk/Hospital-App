using HospitalApp.Models;
using HospitalApp.Models.Entity;
using HospitalApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalApp.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {


        // GET: Employee
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            EmployeeMultiModel employeeMulti = new EmployeeMultiModel();
            employeeMulti.Categories = db.Category.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            employeeMulti.Rooms = db.Room.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            employeeMulti.Departments = db.Department.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            employeeMulti.Employees = db.Employee.Where(x => x.IsDelete == false && x.IsActive == true).ToList();

            return View(employeeMulti);
        }
       


        [HttpGet]

        public ActionResult Create()
        {
            EmployeeMultiModel employeeMulti = new EmployeeMultiModel();
            employeeMulti.Rooms = db.Room.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            employeeMulti.Departments = db.Department.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            employeeMulti.Categories = db.Category.Where(x => x.IsDelete == false && x.IsActive == true).ToList();

  

            return View(employeeMulti);

        }
        [HttpPost]
        public ActionResult Create(Employee Employee)
        {
            Employee EmployeeControl = db.Employee.FirstOrDefault(x => x.Name == Employee.Name || x.Email == Employee.Email);
            if (EmployeeControl != null)
            {
               
                return RedirectToAction("Index");
            }
            Employee newemp = new Employee();

            newemp.Name = Employee.Name;
            newemp.Surname = Employee.Surname;
            newemp.TcNumber = Employee.TcNumber;
            newemp.Phone = Employee.Phone;
            newemp.Birthday = Employee.Birthday;
            newemp.Email = Employee.Email;
            newemp.Image = Employee.Image;
            newemp.DepartmentId = Employee.DepartmentId;
            newemp.CategoryId = Employee.CategoryId;
            newemp.RoomId = Employee.RoomId;
            newemp.Salary = Employee.Salary;
            newemp.IsActive = Employee.IsActive;
            db.Employee.Add(newemp);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            EmployeeMultiModel employeeMulti = new EmployeeMultiModel();
            employeeMulti.Rooms = db.Room.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            employeeMulti.Categories = db.Category.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            employeeMulti.Departments = db.Department.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            employeeMulti.Employee = db.Employee.FirstOrDefault(x => x.Id == Id && x.IsDelete == false);

            if (employeeMulti.Employee == null)
            {
                return RedirectToAction("index");
            }
            return View(employeeMulti);


        }
        [HttpPost]
        public ActionResult Edit(Employee employee, bool? IsActive)
        {

          Employee EmployeeItem = db.Employee.FirstOrDefault(x => x.Id == employee.Id && x.IsDelete == false);
            if (EmployeeItem==null)
            {
                return RedirectToAction("Index");
            }
            EmployeeItem.CategoryId = employee.CategoryId;
            EmployeeItem.Name = employee.Name;
            EmployeeItem.Surname = employee.Surname;
            EmployeeItem.TcNumber = employee.TcNumber;
            EmployeeItem.Phone = employee.Phone;
            EmployeeItem.Birthday = employee.Birthday;
            EmployeeItem.Email = employee.Email;
            EmployeeItem.Image = employee.Image;
            EmployeeItem.DepartmentId = employee.DepartmentId;
            EmployeeItem.RoomId = employee.RoomId;
            EmployeeItem.Salary = employee.Salary;
            EmployeeItem.IsActive = employee.IsActive;
            if (IsActive==null)
            {
                EmployeeItem.IsActive = false;
            }
            else
            {
                EmployeeItem.IsActive = true;
            }
            db.SaveChanges();
            return RedirectToAction("index");
         
        }
        public ActionResult Delete(int Id)
        {
            Employee delEmployee = db.Employee.FirstOrDefault(x=>x.Id==Id);
            if (delEmployee==null)
            {
                return RedirectToAction("Index");
            }
            delEmployee.IsDelete = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
