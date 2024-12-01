﻿using dental_clinic.Core.reposetories;
using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Data.repositories
{
    public class DentistRepository: IDentistRepository
    {
        private readonly DataContext _context = new DataContext();
        public List<dentist> GetAll()
        {
            return _context.Dentists.ToList();
        }
        public dentist GetById(int id)
        {
            return _context.Dentists.ToList().Find(x => x.Id == id);
        }

        public void Add(dentist entist)
        {
             _context.Dentists.Add(entist);
        }

        public void Remove(dentist dentist)
        {
            _context.Dentists.Remove(dentist);
        }
        public void Update(dentist updatedDentist)
        {
            var existingDentist = _context.Dentists.FirstOrDefault(d => d.Id == updatedDentist.Id);

            if (existingDentist != null)
            {
                // עדכון כל השדות של האובייקט הקיים לפי האובייקט החדש
                existingDentist.Name = updatedDentist.Name;
                existingDentist.Email = updatedDentist.Email;
                existingDentist.Salary = updatedDentist.Salary;
                existingDentist.Phone_number = updatedDentist.Phone_number;
                existingDentist.Status = updatedDentist.Status;
                existingDentist.Id = updatedDentist.Id;


                // שמירת העדכון בבסיס הנתונים
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Dentist with ID {updatedDentist.Id} not found.");
            }
        }
    }
}
