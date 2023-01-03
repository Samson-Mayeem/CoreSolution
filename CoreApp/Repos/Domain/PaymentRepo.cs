using CoreApp.Repos.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using DataAccess.CoreApp;
using CoreApp.Models.Domain;


namespace CoreApp.Repos.Domain
{

    public class PaymentRepo : IPaymentRepo
	{
		private readonly string _connectionString = "DbConnection";

		protected PaymentRepo(string connectionString)
		{
			_connectionString = connectionString;
		}


		public async Task<IEnumerable<Wallet>> GetAll() => await LoadData<Wallet, object>("SELECT * FROM payments", new {}, _connectionString);

		public async Task<Wallet> GetById(int id)
		{
			var parameters = new { Id = id };
			return await LoadData<Wallet, object>("SELECT * FROM users WHERE id = @Id", parameters, _connectionString)
				.FirstOrDefault();
		}

		public async Task<Wallet> Add(Wallet wallet)
		{
			string sql = "INSERT INTO wallet (name, email, password) VALUES (@Name, @Email, @Password)";
			await SaveData(sql, wallet, _connectionString);
			return wallet;
		}

		public async Task<Wallet> Update(int id, Wallet wallet)
		{
			var parameters = new { Id = id, wallet.Name, wallet.WalletType, wallet.WalletNumber, wallet.WalletSchema, wallet.WalletCreated, wallet.OwnerPhone };
			await SaveData("UPDATE wallet SET name = @Name, walletType = @WalletType, walletnumber = @Wallet, walletschema=@AccountSchema, walletcreated =@WalletCreated, walletowner=@WalletOwner WHERE id = @Id", parameters, _connectionString);
			return wallet;
		}

		public async Task<Wallet> Delete(int id)
		{
			var wallet = await GetById(id);
			await SaveData("DELETE FROM wallet WHERE id = @Id", new { Id = id }, _connectionString);
			return wallet;
		}
	}

}
