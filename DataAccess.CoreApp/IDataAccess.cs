using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.CoreApp
{
	public interface IDataAccess
	{
		Task<List<T>> LoadData<T, U>(string sql, U paramenters, string connectionString);
		Task SaveData<T>(string sql, T paramenters, string connectionString);
	}
}