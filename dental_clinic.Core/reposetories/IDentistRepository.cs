﻿using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Core.reposetories
{
    public interface IDentistRepository
    {
        public List<dentist> GetAll();
        public void Add(dentist entist);
        public dentist GetById(int id);
        void Remove(dentist dentist);
        void Update(dentist updatedDentist);

    }
}
