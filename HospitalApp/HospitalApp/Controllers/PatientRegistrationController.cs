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
    public class PatientRegistrationController : Controller
    {
        // GET: PatientRegistration
        DataContext db = new DataContext();
        public ActionResult Index()
        {
          
            PatientRegMultiModel PatientRegistrationMulti = new PatientRegMultiModel();

            PatientRegistrationMulti.Users = db.User.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            PatientRegistrationMulti.Patients = db.Patient.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            PatientRegistrationMulti.Employees = db.Employee.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            PatientRegistrationMulti.Procedures = db.Procedure.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            PatientRegistrationMulti.PatientRegistrations = db.PatientRegistration.Where(x => x.IsDelete == false && x.IsActive == true).ToList();

            return View(PatientRegistrationMulti);
        }



        [HttpGet]

        public ActionResult Create()
        {

            PatientRegMultiModel PatientRegistrationMulti = new PatientRegMultiModel();


            PatientRegistrationMulti.Patients = db.Patient.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            PatientRegistrationMulti.Users = db.User.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            PatientRegistrationMulti.Employees = db.Employee.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            PatientRegistrationMulti.Procedures = db.Procedure.Where(x => x.IsDelete == false && x.IsActive == true).ToList();

            return View(PatientRegistrationMulti);

        }
        [HttpPost]
        public ActionResult Create(PatientRegistration PatientRegistration)
        {
            PatientRegistration PatientRegistrationControl = db.PatientRegistration.FirstOrDefault(x => x.Id == PatientRegistration.Id);
            if (PatientRegistrationControl != null)
            {

                return RedirectToAction("Index");
            }
            PatientRegistration newreg = new PatientRegistration();
            newreg.Id = PatientRegistration.Id;
            newreg.PatientId = PatientRegistration.PatientId;
            newreg.UserId = PatientRegistration.UserId;
            newreg.EmployeeId = PatientRegistration.EmployeeId;
            newreg.ProcedureId = PatientRegistration.ProcedureId;
            newreg.TotalPrice = PatientRegistration.TotalPrice;
            newreg.DateHour = PatientRegistration.DateHour;
            newreg.IsDelete = PatientRegistration.IsDelete;
            newreg.IsActive = PatientRegistration.IsActive;

            db.PatientRegistration.Add(newreg);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            PatientRegMultiModel PatientRegistrationMulti = new PatientRegMultiModel();
            PatientRegistrationMulti.Patients = db.Patient.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            PatientRegistrationMulti.Employees = db.Employee.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            PatientRegistrationMulti.Procedures = db.Procedure.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            PatientRegistrationMulti.Users = db.User.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            PatientRegistrationMulti.PatientRegistration = db.PatientRegistration.FirstOrDefault(x => x.Id == Id && x.IsDelete == false);

            if (PatientRegistrationMulti.PatientRegistration == null)
            {
                return RedirectToAction("index");
            }
            return View(PatientRegistrationMulti);

        }
        [HttpPost]
        public ActionResult Edit(PatientRegistration patientRegistration, bool? IsActive)
        {

            PatientRegistration PatientRegItem = db.PatientRegistration.FirstOrDefault(x => x.Id ==patientRegistration.Id && x.IsDelete == false);
            if (PatientRegItem == null)
            {
                return RedirectToAction("Index");

            }
            PatientRegItem.Id = patientRegistration.Id;
            PatientRegItem.PatientId = patientRegistration.PatientId;
            PatientRegItem.UserId = patientRegistration.UserId;
            PatientRegItem.EmployeeId = patientRegistration.EmployeeId;
            PatientRegItem.ProcedureId = patientRegistration.ProcedureId;
            PatientRegItem.TotalPrice = patientRegistration.TotalPrice;
            PatientRegItem.DateHour = patientRegistration.DateHour;
            PatientRegItem.IsDelete = patientRegistration.IsDelete;
            PatientRegItem.IsActive = patientRegistration.IsActive;

            if (IsActive == null)
            {
                PatientRegItem.IsActive = false;
            }
            else
            {
                PatientRegItem.IsActive = true;
            }
            db.SaveChanges();


            return RedirectToAction("index");



          
        }
        public ActionResult Delete(int Id)
        {
            PatientRegistration delPatientReg = db.PatientRegistration.FirstOrDefault(x => x.Id == Id);
            if (delPatientReg == null)
            {
                return RedirectToAction("Index");
            }
            delPatientReg.IsDelete = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}