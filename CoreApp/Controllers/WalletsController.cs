using DataAccess.CoreApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CoreApp.Models.Domain;

namespace CoreApp.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class PaymantController : ControllerBase
	{
		private readonly IDataAccess _userDataAccess;

		public PaymantController(IDataAccess userDataAccess)
		{
			_userDataAccess = userDataAccess;
		}

		[HttpGet]
		[Route("payments")]
		[Route("api/payments")]
		public async Task<ActionResult<IEnumerable<Wallet>>> GetAll()
		{
			var payments = await _userDataAccess.LoadData();
			return Ok(payments);
		}

		[HttpGet("{id}")]
		[Route("payments/{id}")]
		public async Task<ActionResult<Wallet>> GetById(int id)
		{
			var payment = await _userDataAccess.GetById(id);
			if (payment == null)
			{
				return NotFound();
			}
			return Ok(payment);
		}

		[HttpPost]
		[Route("payments")]
		public async Task<ActionResult<Wallet>> Create([FromBody] Wallet payment)
		{
			var newPayment = await _userDataAccess.Add(payment);
			return CreatedAtAction(nameof(GetById), new { id = newPayment.Id }, newPayment);
		}

		[HttpPut("{id}")]
		[Route("payments/{id}")]
		public async Task<ActionResult<Wallet>> Update(int id, [FromBody] Wallet user)
		{
			var updatedPayment = await _userDataAccess.Update(id, user);
			if (updatedPayment == null)
			{
				return NotFound();
			}
			return Ok(updatedPayment);
		}

		[HttpDelete("{id}")]
		[Route("payments/{id}")]
		public async Task<ActionResult<Wallet>> Delete(int id)
		{
			var deletedDelete = await _userDataAccess.Delete(id);
			if (deletedDelete == null)
			{
				return NotFound();
			}
			return Ok(deletedDelete);
		}
	}
}
