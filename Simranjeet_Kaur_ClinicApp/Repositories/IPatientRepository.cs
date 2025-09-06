using Simranjeet_Kaur_ClinicApp.Models;

namespace Simranjeet_Kaur_ClinicApp.Repositories
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAll();
        Patient GetById(int id);
        void Add(Patient patient);
        void Update(Patient patient);
        void Delete(int id);
    }
}
