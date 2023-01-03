using CoreApp.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreApp.Repos.Interfaces
{
    public interface IPaymentRepo
    {
		Task<IEnumerable<Wallet>> GetAll();
		Task<Wallet> GetById(int id);
		Task<Wallet> Add(Wallet user);
		Task<Wallet> Update(int id, Wallet user);
		Task<Wallet> Delete(int id);
	}
}
