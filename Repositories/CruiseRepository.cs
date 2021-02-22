using System.Collections.Generic;
using System.Data;
using Dapper;
using vacay.Models;

namespace vacay.Repositories
{
    public class CruiseRepository
    {
        private readonly IDbConnection _cb;

        public CruiseRepository(IDbConnection cb)
        {
            _cb = cb;
        }

        internal IEnumerable<Cruise> GetAll()
        {
            string sql = "SELECT * FROM cruise;";
            return _cb.Query<Cruise>(sql);
        }

        internal Cruise GetById(int id)
        {
            string sql = "SELECT * FROM cruise WHERE id = @id;";
            return _cb.QueryFirstOrDefault<Cruise>(sql, new { id });
        }

        internal Cruise Create(Cruise newCruise)
        {
            string sql = @"
                INSERT INTO cruise
                    (title, description, start, end, length, price)
                VALUES
                    (@Title, @Description, @Start, @End, @Length, @Price);
                SELECT LAST_INSERT_ID();
                ";
            int id = _cb.ExecuteScalar<int>(sql, newCruise);
            newCruise.Id = id;
            return newCruise;
        }

        internal Cruise Edit(Cruise update)
        {
            string sql = @"
            UPDATE FROM cruise
            SET
                title = @Title,
                description = @Description,
                start = @Start,
                end = @End,
                length = @Length,
                price = @Price
            WHERE id = @Id";
            _cb.Execute(sql, update);
            return update;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM cruise WHERE id = @id LIMIT 1";
            _cb.Execute(sql, new { id });
        }
    }
}