using System;
using System.Collections.Generic;
using flowershop.Models;
using flowershop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace flowershop.Service
{
    public class FlowersService
    {
        private readonly FlowersRepository _repo;

        public FlowersService(FlowersRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Flower> GetAll()
        {
            return _repo.GetAll();
        }

        internal Flower GetById(int id)
        {
            Flower Flower = _repo.GetById(id);
            if (Flower == null)
            {
                throw new Exception("invalid Id");
            }
            return Flower;
        }

        internal Flower Create(Flower newFlower)
        {
            return _repo.Create(newFlower);
        }

        internal Flower Edit(Flower updated)
        {
            var original = GetById(updated.Id);

            updated.name = updated.name != null ? updated.name : original.name;
            updated.description = updated.description != null ? updated.description : original.description;
            updated.price = updated.price > 0 ? updated.price : original.price;

            return _repo.Edit(updated);

        }

        internal string Delete(int id)
        {
            var data = GetById(id);
            _repo.Delete(id);
            return "Deleted Flower";
        }
    }
}