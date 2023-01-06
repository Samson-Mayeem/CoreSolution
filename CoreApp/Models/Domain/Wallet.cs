using CoreApp.Models.Enums;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Web.Providers.Entities;

namespace CoreApp.Models.Domain
{
	
	public class Wallet
    {
        public long Id { get; set; }  
        string Name { get; set; }
		Type WalletType { get; set; }
		AccountNumber AccountNumber { get; set; }
        AccountSchema AccountSchema { get; set; }
        DateAndTime WalletCreated { get; set; }
        long OwnerPhone { get; set; }   
    }
}
