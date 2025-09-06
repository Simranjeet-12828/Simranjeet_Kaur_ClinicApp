﻿using Simranjeet_Kaur_ClinicApp.Models;

namespace Simranjeet_Kaur_ClinicApp.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ClinicDBContext _context;

        public PatientRepository(ClinicDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Patient> GetAll() => _context.Patients.ToList();
        public Patient GetById(int id) => _context.Patients.Find(id);
        public void Add(Patient patient) { _context.Patients.Add(patient); _context.SaveChanges(); }
        public void Update(Patient patient) { _context.Patients.Update(patient); _context.SaveChanges(); }
        public void Delete(int id)
        {
            var p = _context.Patients.Find(id);
            if (p != null) { _context.Patients.Remove(p); _context.SaveChanges(); }
        }
    }

}
