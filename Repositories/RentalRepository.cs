using System.Collections.Generic;
using System.Data;
using Dapper;
using vacay.Models;

namespace vacay.Repositories
{
    public class RentalRepository
    {
        private readonly IDbConnection _rb;

        public RentalRepository(IDbConnection rb)
        {
            _rb = rb;
        }

        internal IEnumerable<Rental> GetAll()
        {
            string sql = "SELECT * FROM rental;";
            return _rb.Query<Rental>(sql);
        }

        internal Rental GetById(int id)
        {
            string sql = "SELECT * FROM rental WHERE id = @id;";
            return _rb.QueryFirstOrDefault<Rental>(sql, new { id });
        }

        internal Rental Create(Rental newRental)
        {
            string sql = @"
                INSERT INTO rental
                    (title, description, duration, miles, price)
                VALUES
                    (@Title, @Description, @duration, @Miles, @Price);
                SELECT LAST_INSERT_ID();
                ";
            int id = _rb.ExecuteScalar<int>(sql, newRental);
            newRental.Id = id;
            return newRental;
        }

        internal Rental Edit(Rental update)
        {
            string sql = @"
            UPDATE FROM rental
            SET
                title = @Title,
                description = @Description,
                duration = @Duration,
                miles = @Miles,
                price = @Price
            WHERE id = @Id";
            _rb.Execute(sql, update);
            return update;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM rental WHERE id = @id LIMIT 1";
            _rb.Execute(sql, new { id });
        }
    }
}