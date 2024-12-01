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
    public class TurnService : ITurnServices
    {
        private readonly ITurnRepository _turnRepository;
        public TurnService(ITurnRepository turnRepository)
        {
            _turnRepository = turnRepository;
        }
        public List<turn> GetList()
        {
            return _turnRepository.GetAll();
        }

        List<turn> ITurnServices.GetList()
        {
            throw new NotImplementedException();
        }
        public turn GetById(int id)
        {
            //חישוב
            //לדוגמא אפשר לבדוק תאריך לידה \ גיל על תלמידה הנוכחית
            return _turnRepository.GetById(id);
        }
        public void Add(turn turn)
        {
            _turnRepository.Add(turn);
        }
        public void Delete(turn turn)
        {
            _turnRepository.Remove(_turnRepository.GetById(turn.Id));
        }

        public void Remove(turn turn)
        {
            throw new NotImplementedException();
        }
        public void Put(turn updatedTurn)
        {
            _turnRepository.Update(updatedTurn);
        }
    }

}
