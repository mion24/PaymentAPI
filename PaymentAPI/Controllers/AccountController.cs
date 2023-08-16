using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PaymentAPI.Data;
using PaymentAPI.Models;
using PaymentAPI.ResultViewModel;
using PaymentAPI.ResultViewModel.Transactions;
using PaymentAPI.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PaymentAPI.Controllers
{
    [ApiController]
    
    public class AccountController : ControllerBase
    {
        [HttpGet("index")]
        [Authorize]
        public async Task<IActionResult> GetDataAsync([FromServices] AppDbContext context, [FromServices] TokenService tokenService)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ResultViewModel<string>("09x231 - Falha ao carregar dados da conta."));
                }

                var userId = int.Parse(User?.Claims?.FirstOrDefault(x => x.Type == "UserID")?.Value);

                List<Transaction> TransactionList = await context.Payments.Where(x => x.SenderId == userId).ToListAsync();

                return Ok(TransactionList);

            }
            catch
            {
                return StatusCode(500, new ResultViewModel<string>("05x913 - Falha interna do servidor."));
            }
        }

        [HttpPost("index/transactions")]
        [Authorize]
        public async Task<IActionResult> PostTransactions([FromServices] AppDbContext context, [FromBody] TransactionViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ResultViewModel<string>("09x231 - Falha ao carregar dados da transação."));
                }

                var transaction = new Transaction
                {
                    Doc = Guid.NewGuid().ToString(),
                    DocValue = model.DocValue,
                    SenderId = int.Parse(User?.Claims?.FirstOrDefault(x => x.Type == "UserID")?.Value),
                    IdReceiver = model.IdReceiver,
                };

                await context.Payments.AddAsync(transaction);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<dynamic>(new
                {
                    Data = transaction.Doc
                }));
            }
            catch 
            {
                return StatusCode(500, new ResultViewModel<string>("0923x13 - Falha interna no servidor"));
            }         
        }

    }
}
