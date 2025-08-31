using System.Data;
using Dapper;

namespace SuperPoc.BuildingBlocks.Infrastructure.Persistence
{
    public class DapperRepository
    {
        private readonly IDbConnection _connection;

        public DapperRepository(IDbConnection connection) => _connection = connection;

        public async Task<T?> QuerySingleAsync<T>(string sql, object? param = null) =>
            await _connection.QuerySingleOrDefaultAsync<T>(sql, param);

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null) =>
            await _connection.QueryAsync<T>(sql, param);
    }
}
