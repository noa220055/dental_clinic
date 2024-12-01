using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Core.services
{
    public interface IPatientServices
    {
        public List<patient> GetList();
        public void Add(patient entist);
        public patient GetById(int id);
        public void Remove(patient patient);
        public void Put(patient updatedPatient);
    }
}
