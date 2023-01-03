﻿using CoreApp.Models.Enums;
using Microsoft.VisualBasic;

namespace CoreApp.Models.Domain
{
    public class Wallet
    {
        long Id { get; set; }  
        string Name { get; set; }
		Type WalletType { get; set; }
		AccountNumber AccountNumber { get; set; }
        AccountSchema AccountSchema { get; set; }
        DateAndTime WalletCreated { get; set; }
        long OwnerPhone { get; set; }   
    }
}
