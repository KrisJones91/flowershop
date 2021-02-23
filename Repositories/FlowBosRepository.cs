using System.Data;
using Dapper;
using flowershop.Models;

namespace flowershop.Repositories
{
    public class FlowBosRepository
    {
        private readonly IDbConnection _fb;

        public FlowBosRepository(IDbConnection fb)
        {
            _fb = fb;
        }

        public int Create(FlowBo newFb)
        {
            string sql = @"
                INSERT INTO FlowBos
                    (flowerId, boquetId)
                VALUES
                    (@FlowerId, @BoquetId);
                SELECT LAST_INSERT_ID();";
            return _fb.ExecuteScalar<int>(sql, newFb);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM FlowBos WHERE id = @id;";
            _fb.Execute(sql, new { id });
        }

    }
}