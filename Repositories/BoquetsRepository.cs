using System.Collections.Generic;
using System.Data;
using Dapper;
using flowershop.Models;

namespace Boquetshop.Repositories
{
    public class BoquetsRepository
    {
        private readonly IDbConnection _bb;

        public BoquetsRepository(IDbConnection bb)
        {
            _bb = bb;
        }

        internal IEnumerable<Boquet> GetAll()
        {
            string sql = "SELECT * FROM Boquets;";
            return _bb.Query<Boquet>(sql);
        }

        internal Boquet GetById(int id)
        {
            string sql = "SELECT * FROM Boquets WHERE id = @id;";
            return _bb.QueryFirstOrDefault<Boquet>(sql, new { id });
        }

        internal Boquet Create(Boquet newBoquet)
        {
            string sql = @"
                INSERT INTO Boquets
                    (name, description, color, price, wrap, amount)
                VALUES
                    (@name, @description, @color, @price @wrap, @amount);
                SELECT LAST_INSERT_ID();
                ";
            int id = _bb.ExecuteScalar<int>(sql, newBoquet);
            newBoquet.Id = id;
            return newBoquet;
        }

        internal Boquet Edit(Boquet update)
        {
            string sql = @"
                UPDATE FROM Boquets
                SET
                    name = @name,
                    color = @color,
                    description = @description,
                    price = @price,
                    wrap = @wrap,
                    amount = @amount
                WHERE id = @Id";
            _bb.Execute(sql, update);
            return update;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM Boquets WHERE id = @id LIMIT 1";
            _bb.Execute(sql, new { id });
        }
    }
}