using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Data;
using PaymentAPI.Extensions;
using PaymentAPI.Models;
using PaymentAPI.ResultViewModel;
using PaymentAPI.ResultViewModel.RegisterViewModel;
using PaymentAPI.Services;
using SecureIdentity.Password;

namespace PaymentAPI.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("/register")]
        public async Task<IActionResult> CreateUser([FromServices] AppDbContext context, [FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));
            }

            var user = new User { UserName = model.Email, Email = model.Email };

            var password = model.Password;

            user.Password = PasswordHasher.Hash(password);

            try
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<dynamic>(new
                {
                    user = user.Email,
                    password
                }));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<string>("05X9134 - Falha interna no servidor."));
            }
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromServices] AppDbContext context, [FromServices] TokenService tokenService, [FromBody] LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));
                }

                var user = await context
                    .Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Email == model.Email);

                if (user is null)
                {
                    return StatusCode(401, new ResultViewModel<string>("05x9584 - Falha ao carregar usuario."));
                }

                //if (!PasswordHasher.Verify(user.Password, model.Password))
                //{
                //    return StatusCode(401, new ResultViewModel<string>("Usuario ou senha invalidos"));
                //}

                var token = tokenService.GenerateToken(user);

                return Ok(new ResultViewModel<string>(token));

            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<string>("05X04 - Falha interna no servidor."));
            }
        }
    }
}

