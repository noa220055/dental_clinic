using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Core.reposetories
{
    public interface IPatientRepository
    {
        public List<patient> GetAll();
        public void Add(patient entist);
        public patient GetById(int id);
        void Remove(patient patient);
        void Update(patient updatedPatient);
    }
}
