using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simranjeet_Kaur_ClinicApp.Models;
using Simranjeet_Kaur_ClinicApp.Repositories;

namespace Simranjeet_Kaur_ClinicApp.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientRepository _repo;

        public PatientsController(IPatientRepository repo)
        {
            _repo = repo;
        }

        // GET: Patients
        public async Task<IActionResult> Index()
        {
            var patients = await Task.FromResult(_repo.GetAll());
            return View(patients);
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await Task.FromResult(_repo.GetById(id.Value));
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,City,DoctorAssigned")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(patient);
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await Task.FromResult(_repo.GetById(id.Value));
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,City,DoctorAssigned,DateOfBirth")] Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repo.Update(patient);
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await Task.FromResult(_repo.GetById(id.Value));
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
