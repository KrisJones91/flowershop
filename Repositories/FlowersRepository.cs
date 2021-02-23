using System.Collections.Generic;
using System.Data;
using Dapper;
using flowershop.Models;

namespace flowershop.Repositories
{
    public class FlowersRepository
    {
        private readonly IDbConnection _db;

        public FlowersRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Flower> GetAll()
        {
            string sql = "SELECT * FROM Flowers;";
            return _db.Query<Flower>(sql);
        }

        internal Flower GetById(int id)
        {
            string sql = "SELECT * FROM Flowers WHERE id = @id;";
            return _db.QueryFirstOrDefault<Flower>(sql, new { id });
        }

        internal Flower Create(Flower newFlower)
        {
            string sql = @"
                INSERT INTO Flowers
                    (name, description, color, price)
                VALUES
                    (@name, @description, @color, @price);
                SELECT LAST_INSERT_ID();
                ";
            int id = _db.ExecuteScalar<int>(sql, newFlower);
            newFlower.Id = id;
            return newFlower;
        }

        internal Flower Edit(Flower update)
        {
            string sql = @"
                UPDATE FROM Flowers
                SET
                    name = @name,
                    description = @description,
                    color = @color,
                    price = @price
                WHERE id = @Id";
            _db.Execute(sql, update);
            return update;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM Flowers WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });
        }
    }
}