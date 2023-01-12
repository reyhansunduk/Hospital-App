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
    public class PrescriptionController : Controller
    {
        // GET: Prescription
     
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            PrescriptionMultiModel prescriptionMulti = new PrescriptionMultiModel();

            prescriptionMulti.Prescriptions = db.Prescription.Where(x => x.IsDelete == false).ToList();
            prescriptionMulti.Procedures = db.Procedure.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            prescriptionMulti.Users = db.User.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
           
            return View(prescriptionMulti);
        }

        [HttpGet]

        public ActionResult Create()
        {
            PrescriptionMultiModel prescriptionMulti = new PrescriptionMultiModel();
            prescriptionMulti.Procedures = db.Procedure.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            prescriptionMulti.Users = db.User.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            return View(prescriptionMulti);

        

        }
        [HttpPost]
        public ActionResult Create(Prescription Prescription)
        {
            Prescription PrescriptionControl = db.Prescription.FirstOrDefault(x => x.Name == Prescription.Name);
            if (PrescriptionControl != null)
            {

                return RedirectToAction("Index");
            }
            Prescription newpres = new Prescription();

            newpres.Name = Prescription.Name;
            newpres.ProcedureId = Prescription.ProcedureId;
            newpres.UserId = Prescription.UserId;
            newpres.IsActive = Prescription.IsActive;
            db.Prescription.Add(newpres);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            PrescriptionMultiModel prescriptionMulti = new PrescriptionMultiModel();
            prescriptionMulti.Procedures = db.Procedure.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            prescriptionMulti.Users = db.User.Where(x => x.IsDelete == false && x.IsActive == true).ToList();
            prescriptionMulti.Prescription = db.Prescription.FirstOrDefault(x => x.Id == Id && x.IsDelete == false);

            if (prescriptionMulti.Prescription == null)
            {
                return RedirectToAction("index");
            }
            return View(prescriptionMulti);

        }
        [HttpPost]
        public ActionResult Edit(Prescription prescription, bool? IsActive)
        {

            Prescription PrescriptionItem = db.Prescription.FirstOrDefault(x => x.Id == prescription.Id && x.IsDelete == false);
            if (PrescriptionItem == null)
            {
                return RedirectToAction("Index");
            }
            PrescriptionItem.Name = prescription.Name;
            PrescriptionItem.ProcedureId = prescription.ProcedureId;
            PrescriptionItem.UserId = prescription.UserId;
            PrescriptionItem.IsActive = prescription.IsActive;
            if (IsActive == null)
            {
                PrescriptionItem.IsActive = false;
            }
            else
            {
                PrescriptionItem.IsActive = true;
            }
            db.SaveChanges();


            return RedirectToAction("index");
        }
        public ActionResult Delete(int Id)
        {
            Prescription delPrescription = db.Prescription.FirstOrDefault(x => x.Id == Id);
            if (delPrescription == null)
            {
                return RedirectToAction("Index");
            }
            delPrescription.IsDelete = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}