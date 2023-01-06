using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CoreApp.Models.Domain;
using CoreApp.Repos.Interfaces;
using CoreApp.Repos.Domain;

namespace CoreApp.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class PaymantController : ControllerBase
	{
		private readonly IWalletRepo _walletRepo;

		public PaymantController(IWalletRepo walletRepo)
		{
			walletRepo = _walletRepo;
		}

		[HttpGet]
		[Route("wallets")]
		[Route("api/wallets")]
		public async Task<ActionResult<IEnumerable<Wallet>>> GetAll()
		{
			var payments = await _walletRepo.GetAll();
			return Ok(payments);
		}

		[HttpGet("{id}")]
		[Route("api/wallets/{id}")]
		public async Task<ActionResult<Wallet>> GetById(int id)
		{
			var wallet = await _walletRepo.GetById(id);
			if (wallet == null)
			{
				return NotFound();
			}
			return Ok(wallet);
		}

		[HttpPost]
		[Route("api/wallets")]
		public async Task<ActionResult<Wallet>> Create([FromBody] Wallet wallet)
		{
			var newWallet = await _walletRepo.Add(wallet);
			return CreatedAtAction(nameof(GetById), new { id = newWallet.Id }, newWallet);
		}

		[HttpPut("{id}")]
		[Route("api/wallets/{id}")]
		public async Task<ActionResult<Wallet>> Update(int id, [FromBody] Wallet user)
		{
			var updatedPayment = await _walletRepo.Update(id, user);
			if (updatedPayment == null)
			{
				return NotFound();
			}
			return Ok(updatedPayment);
		}

		[HttpDelete("{id}")]
		[Route("api/wallets/{id}")]
		public async Task<ActionResult<Wallet>> Delete(int id)
		{
			var deletedDelete = await _walletRepo.Delete(id);
			if (deletedDelete == null)
			{
				return NotFound();
			}
			return Ok(deletedDelete);
		}
	}
}
