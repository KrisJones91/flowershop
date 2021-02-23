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
        private readonly BoquetsRepository _brepo;
        public FlowersService(FlowersRepository repo, BoquetsRepository brepo)
        {
            _repo = repo;
            _brepo = brepo;

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

        internal IEnumerable<Flower> GetFlowersByBoquetId(int flowerId)
        {
            Boquet exists = _brepo.GetById(flowerId);
            if (exists == null)
            {
                throw new Exception("Invalid Id");
            }
            return _repo.GetFlowersByBoquetId(flowerId);
        }
    }
}