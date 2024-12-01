using dental_clinic.Core.reposetories;
using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Data.repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DataContext _context = new DataContext();
        public List<patient> GetAll()
        {
            return _context.Patients.ToList();
        }
        public patient GetById(int id)
        {
            return _context.Patients.ToList().Find(x => x.Id == id);
        }
        public void Add(patient entist)
        {
            _context.Patients.Add(entist);
        }

        public void Remove(patient patient)
        {
            _context.Patients.Remove(patient);
        }
        public void Update(patient updatedPatient)
        {
            var existingPatient = _context.Patients.FirstOrDefault(d => d.Id == updatedPatient.Id);

            if (existingPatient != null)
            {
                // עדכון כל השדות של האובייקט הקיים לפי האובייקט החדש
                existingPatient.Name = updatedPatient.Name;
                existingPatient.Email = updatedPatient.Email;
                existingPatient.Address = updatedPatient.Address;
                existingPatient.Phone_number = updatedPatient.Phone_number;
                existingPatient.Status = updatedPatient.Status;
                existingPatient.Id = updatedPatient.Id;


                // שמירת העדכון בבסיס הנתונים
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Dentist with ID {updatedPatient.Id} not found.");
            }
        }
    }
}
