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
    public class PatientController : Controller
    {
       
        // GET: Patient
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            PatientMultiModel patientMulti = new PatientMultiModel();

            patientMulti.Users = db.User.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            patientMulti.Rooms = db.Room.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            patientMulti.Patients = db.Patient.Where(x => x.IsDelete == false && x.IsActive == true).ToList();

            return View(patientMulti);
          
        }
        [HttpGet]

        public ActionResult Create()
        {
            PatientMultiModel patientMulti = new PatientMultiModel();
            patientMulti.Rooms = db.Room.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            patientMulti.Users = db.User.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            return View(patientMulti);

           

        }
        [HttpPost]
        public ActionResult Create(Patient Patient)
        {
            Patient PatientControl = db.Patient.FirstOrDefault(x => x.Name == Patient.Name);
            if (PatientControl != null)
            {

                return RedirectToAction("Index");
            }
            Patient newPatient = new Patient();

            newPatient.Name = Patient.Name;
            newPatient.Surname = Patient.Surname;
            newPatient.TcNumber = Patient.TcNumber;
            newPatient.Phone = Patient.Phone;
            newPatient.Birthday = Patient.Birthday;
            newPatient.UserId = Patient.UserId;
            newPatient.RoomId = Patient.RoomId;
            newPatient.IsActive = Patient.IsActive;
            db.Patient.Add(newPatient);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            PatientMultiModel patientMulti = new PatientMultiModel();
            patientMulti.Rooms = db.Room.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            patientMulti.Users = db.User.Where(x=> x.IsDelete == false && x.IsActive == true).ToList();
            patientMulti.Patient = db.Patient.FirstOrDefault(x => x.Id == Id && x.IsDelete == false);

            if (patientMulti.Patient == null)
            {
                return RedirectToAction("index");
            }
            return View(patientMulti);

        }
        [HttpPost]
        public ActionResult Edit(Patient patient,bool? IsActive)
        {
            Patient PatientItem = db.Patient.FirstOrDefault(x=> x.Id == patient.Id && x.IsDelete==false );
            if(PatientItem == null)
            {
                return RedirectToAction("Index");
            }
            PatientItem.UserId = patient.UserId;
            PatientItem.RoomId = patient.RoomId;
            PatientItem.Surname = patient.Surname;
            PatientItem.TcNumber = patient.TcNumber;
            PatientItem.Phone = patient.Phone;
            PatientItem.Birthday = patient.Birthday;
            PatientItem.Name = patient.Name;
            PatientItem.IsActive = patient.IsActive;
            if(IsActive == null)
            {
                PatientItem.IsActive = false;
            }
            else
            {
                PatientItem.IsActive = true;
            }
            db.SaveChanges();


            return RedirectToAction("index");
        }
        public ActionResult Delete(int Id)
        {
            Patient delPatient = db.Patient.FirstOrDefault(x => x.Id == Id);
            if(delPatient == null)
            {
                return RedirectToAction("Index");
            }
            delPatient.IsDelete = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}