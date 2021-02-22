using System;
using System.Collections.Generic;
using vacay.Models;
using vacay.Repositories;

namespace vacay.Services
{
    public class RentalsService
    {
        private readonly RentalRepository _repo;

        public RentalsService(RentalRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Rental> GetAll()
        {
            return _repo.GetAll();
        }

        internal Rental GetById(int id)
        {
            var trip = _repo.GetById(id);
            if (trip == null)
            {
                throw new Exception("invalid Id");
            }
            return trip;
        }

        internal Rental Create(Rental newRental)
        {
            return _repo.Create(newRental);
        }

        internal Rental Edit(Rental updated)
        {
            var original = GetById(updated.Id);

            updated.car = updated.car != null ? updated.car : original.car;
            updated.description = updated.description != null ? updated.description : original.description;
            updated.duration = updated.duration > 0 ? updated.duration : original.duration;
            updated.miles = updated.miles > 0 ? updated.miles : original.miles;
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