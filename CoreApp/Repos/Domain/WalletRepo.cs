using CoreApp.Repos.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreApp.Models.Domain;
using System.Data;
using MySqlConnector;
using Dapper;

namespace CoreApp.Repos.Domain
{

	public class WalletRepo //: //IWalletRepo
	{
		private readonly string _connectionString = "DbConnection";

		protected WalletRepo(string connectionString)
		{
			_connectionString = connectionString;
		}


		public async Task<IEnumerable<Wallet>> GetAll()
		{
			using (IDbConnection connection = new MySqlConnection(_connectionString))
			{
				var wallets = await connection.QueryAsync<Wallet>("SELECT * FROM wallets");
				return wallets;
			}
		}

		public async Task<Wallet> GetById(int id)
		{
			using (IDbConnection connection = new MySqlConnection(_connectionString))
			{
				var wallet = await connection.QueryFirstOrDefaultAsync<Wallet>("SELECT * FROM wallets WHERE id = @Id", new { id });
				return wallet;
			}
		}

		public async Task<Wallet> Add(Wallet wallet)
		{
			
			using (IDbConnection connection = new MySqlConnection(_connectionString))
			{
				var sql = "INSERT INTO wallets (id,name walletType,walletnumber,walletschema,walletcreated,walletowner) VALUES (@id, @Name, @WalletType,@Walletnumber,@Walletschema,@Walletcreated,@Walletowner); SELECT LAST_INSERT_ID();";
				var newWalletId = await connection.ExecuteScalarAsync<int>(sql, wallet);
				wallet.Id = newWalletId;
				return wallet;
			}
		}

		public async Task<Wallet> Update(int id, Wallet wallet)
		{
			using (IDbConnection connection = new MySqlConnection(_connectionString))
			{
				var sql = "UPDATE wallets SET name = @Name, walletType = @WalletType, walletnumber = @Wallet, walletschema=@AccountSchema, walletcreated =@WalletCreated, walletowner=@WalletOwner WHERE id = @Id";
				await connection.ExecuteAsync(sql, wallet);
				return wallet;
			}
		}

		public async Task<Wallet> Delete(int id)
		{
			using (IDbConnection connection = new MySqlConnection(_connectionString))
			{
				var wallet = await GetById(id);
				if (wallet == null)
				{
					return null;
				}
				var sql = "DELETE FROM wallets WHERE id = @Id";
				await connection.ExecuteAsync(sql, new { id });
				return wallet;
			}
		}

	}
}
