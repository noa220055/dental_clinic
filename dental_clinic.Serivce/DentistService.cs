﻿using dental_clinic.Core.reposetories;
using dental_clinic.Core.services;
using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Serivce
{
    public class DentistService : IDentistServices
    {
        private readonly IDentistRepository _dentistRepository;
        public DentistService(IDentistRepository dentistRepository)
        {
            _dentistRepository = dentistRepository;
        }

        public List<dentist> GetList()
        {
            return _dentistRepository.GetAll();
        }

        public dentist GetById(int id)
        {
            //חישוב
            //לדוגמא אפשר לבדוק תאריך לידה \ גיל על תלמידה הנוכחית
            return _dentistRepository.GetById(id);
        }
        public void Add(dentist dentist)
        {
            _dentistRepository.Add(dentist);
        }
        public void Delete(dentist dentist)
        {
            _dentistRepository.Remove(_dentistRepository.GetById(dentist.Id));
        }

        public void Remove(dentist dentist)
        {
            throw new NotImplementedException();
        }
        public void Put(dentist updatedDentist)
        {
            _dentistRepository.Update(updatedDentist);
        }
    }
}
 