using System.Collections.Generic;
using System.Data;
using Dapper;
using vacay.Models;

namespace vacay.Repositories
{
    public class TripRepository
    {
        private readonly IDbConnection _db;

        public TripRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Trip> GetAll()
        {
            string sql = "SELECT * FROM trips;";
            return _db.Query<Trip>(sql);
        }

        internal Trip GetById(int id)
        {
            string sql = "SELECT * FROM trips WHERE id = @id;";
            return _db.QueryFirstOrDefault<Trip>(sql, new { id });
        }

        internal Trip Create(Trip newTrip)
        {
            string sql = @"
                INSERT INTO trips
                    (title, description, price)
                VALUES
                    (@Title, @Description, @Price);
                SELECT LAST_INSERT_ID();
                ";
            int id = _db.ExecuteScalar<int>(sql, newTrip);
            newTrip.Id = id;
            return newTrip;
        }

        internal Trip Edit(Trip update)
        {
            string sql = @"
                UPDATE FROM trips
                SET
                    title = @Title,
                    description = @Description,
                    price = @Price
                WHERE id = @Id";
            _db.Execute(sql, update);
            return update;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM trips WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });
        }
    }
}