using Expense_tracker_api.Application.DTOs.Transaction;
using Expense_tracker_api.Application.Interfaces;
using Expense_tracker_api.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Expense_tracker_api.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTransactionDto dto)
        {
            var userId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            await _transactionService.CreateAsync(dto, userId);
            return Ok();
        }
    }
}
