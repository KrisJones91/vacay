using System;
using System.Collections.Generic;
using vacay.Models;
using vacay.Repositories;

namespace vacay.Services
{
    public class TripsService
    {
        private readonly TripRepository _repo;

        public TripsService(TripRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Trip> GetAll()
        {
            return _repo.GetAll();
        }

        internal Trip GetById(int id)
        {
            var trip = _repo.GetById(id);
            if (trip == null)
            {
                throw new Exception("invalid Id");
            }
            return trip;
        }

        internal Trip Create(Trip newTrip)
        {
            return _repo.Create(newTrip);
        }

        internal Trip Edit(Trip updated)
        {
            var original = GetById(updated.Id);

            updated.title = updated.title != null ? updated.title : original.title;
            updated.description = updated.description != null ? updated.description : original.description;
            updated.price = updated.price > 0 ? updated.price : original.price;

            return _repo.Edit(updated);

        }

        internal string Delete(int id)
        {
            var data = GetById(id);
            _repo.Delete(id);
            return "Deleted Trip";
        }
    }
}