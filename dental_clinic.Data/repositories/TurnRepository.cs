using dental_clinic.Core.reposetories;
using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Data.repositories
{
    public class TurnRepository : ITurnRepository
    {
        private readonly DataContext _context=new DataContext();
        public List<turn> GetAll()
        {
            return _context.Turn.ToList();
        }
        public turn GetById(int id)
        {
            return _context.Turn.ToList().Find(x => x.Id == id);
        }
        public void Add(turn entist)
        {
            _context.Turn.Add(entist);
        }

        public void Remove(turn turn)
        {
            _context.Turn.Remove(turn);
        }
        public void Update(turn updatedTurn)
        {
            var existingTurn = _context.Turn.FirstOrDefault(d => d.Id == updatedTurn.Id);

            if (existingTurn != null)
            {
                // עדכון כל השדות של האובייקט הקיים לפי האובייקט החדש
                existingTurn.Date = updatedTurn.Date;
                existingTurn.TurnNum = updatedTurn.TurnNum;
                existingTurn.Time = updatedTurn.Time;
                existingTurn.Type = updatedTurn.Type;
                existingTurn.DurantionOfTreatment = updatedTurn.DurantionOfTreatment;
                existingTurn.DoctorName = updatedTurn.DoctorName;
                existingTurn.Id = updatedTurn.Id;


                // שמירת העדכון בבסיס הנתונים
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Dentist with ID {updatedTurn.Id} not found.");
            }
        }
    }
}
