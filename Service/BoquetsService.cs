using System;
using System.Collections.Generic;
using flowershop.Repositories;
using flowershop.Models;

namespace flowershop.Service
{
    public class BoquetsService
    {
        private readonly BoquetsRepository _repo;

        public BoquetsService(BoquetsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Boquet> GetAll()
        {
            return _repo.GetAll();
        }

        internal Boquet GetById(int id)
        {
            Boquet Boquet = _repo.GetById(id);
            if (Boquet == null)
            {
                throw new Exception("invalid Id");
            }
            return Boquet;
        }

        internal Boquet Create(Boquet newBoquet)
        {
            return _repo.Create(newBoquet);
        }

        internal Boquet Edit(Boquet updated)
        {
            var original = GetById(updated.Id);

            updated.name = updated.name != null ? updated.name : original.name;
            updated.description = updated.description != null ? updated.description : original.description;
            updated.price = updated.price > 0 ? updated.price : original.price;
            updated.amount = updated.amount > 0 ? updated.amount : original.amount;
            updated.wrap = updated.wrap != false ? updated.wrap : original.wrap;

            return _repo.Edit(updated);

        }

        internal string Delete(int id)
        {
            var data = GetById(id);
            _repo.Delete(id);
            return "Deleted Boquet";
        }
    }
}