using dental_clinic.Core.reposetories;
using dental_clinic.Core.services;
using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Serivce
{
    public class PatientService : IPatientServices
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public List<patient> GetList()
        {
            return _patientRepository.GetAll();
        }

        List<patient> IPatientServices.GetList()
        {
            throw new NotImplementedException();
        }
        public patient GetById(int id)
        {
            //חישוב
            //לדוגמא אפשר לבדוק תאריך לידה \ גיל על תלמידה הנוכחית
            return _patientRepository.GetById(id);
        }
        public void Add(patient patient)
        {
            _patientRepository.Add(patient);
        }
        public void Delete(patient patient)
        {
            _patientRepository.Remove(_patientRepository.GetById(patient.Id));
        }

        public void Remove(patient patient)
        {
            throw new NotImplementedException();
        }
        public void Put(patient updatedPatient)
        {
            _patientRepository.Update(updatedPatient);
        }
    }

}
