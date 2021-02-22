using System;
using System.Collections.Generic;
using vacay.Models;
using vacay.Repositories;

namespace vacay.Services
{
    public class CruiseService
    {
        private readonly CruiseRepository _repo;

        public CruiseService(CruiseRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Cruise> GetAll()
        {
            return _repo.GetAll();
        }

        internal Cruise GetById(int id)
        {
            var trip = _repo.GetById(id);
            if (trip == null)
            {
                throw new Exception("invalid Id");
            }
            return trip;
        }

        internal Cruise Create(Cruise newCruise)
        {
            return _repo.Create(newCruise);
        }

        internal Cruise Edit(Cruise updated)
        {
            Cruise original = GetById(updated.Id);

            original.title = updated.title != null ? updated.title : original.title;
            original.description = updated.description != null ? updated.description : original.description;
            original.start = updated.start != null ? updated.start : original.start;
            original.end = updated.end != null ? updated.end : original.end;
            original.length = updated.length > 0 ? updated.length : original.length;
            original.price = updated.price > 0 ? updated.price : original.price;

            return _repo.Edit(original);

        }

        internal string Delete(int id)
        {
            var data = GetById(id);
            _repo.Delete(id);
            return "Deleted Cruise";
        }
    }
}