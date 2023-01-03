using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CoreApp
{
	public class DataAccessLib : IDataAccess
	{
		public async Task<List<T>> LoadData<T, U>(string sql, U paramenters, string connectionString)
		{
			using (IDbConnection connection = new MySqlConnection(connectionString))
			{
				var rows = await connection.QueryAsync<T>(sql, paramenters);
				return rows.ToList();
			}
		}

		public Task SaveData<T>(string sql, T paramenters, string connectionString)
		{
			using (IDbConnection connection = new MySqlConnection(connectionString))
			{
				return connection.ExecuteAsync(sql, paramenters);
			}
		}
	}
}
