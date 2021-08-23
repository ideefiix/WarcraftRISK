using Microsoft.AspNetCore.Mvc;
using WarcraftApi.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WarcraftApi.RequestObject;
using WarcraftApi.Entities;
using WarcraftApi.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using WarcraftApi.Data;
using Microsoft.AspNetCore.Http;
using WarcraftApi.ResponseObject;

namespace WarcraftApi.Controllers
{
    [ApiController]
    public class TokenController : Controller
    {
        private readonly DBcontext _context;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _config;
        private string generatedToken = null;

        public TokenController(DBcontext context, ITokenService tokenService, IConfiguration config)
        {
            _context = context;
            _tokenService = tokenService;
            _config = config;
        }

        [AllowAnonymous]
        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> login([FromBody] LoginRequest l)
        {

            Player player = await _context.Players.FirstOrDefaultAsync<Player>((x => x.Name == l.playerName));
            if (player == null) return Unauthorized();

            if (player.Password != l.playerPassword) return Unauthorized("Kontrollera ditt lösenord");

            // THE USER HAS AN ACCOUNT AND SHOULD RECIVE TOKEN
            PlayerDTO p = new PlayerDTO
            {
                UserName = l.playerName,
                Password = l.playerPassword

            };
            generatedToken = _tokenService.BuildToken(_config["JwtConfig:Secret"].ToString(), _config["JwtConfig:Issuer"].ToString(), p);
            if (generatedToken != null)
            {
                HttpContext.Session.SetString("Token", generatedToken);
                LoginResponse loginResponse = new LoginResponse {
                    playerName = player.Name,
                    playerID = player.Id,
                    Token = generatedToken
                };

                return Ok(loginResponse);
            }
            else
            {
                return (BadRequest("Unable to create a token"));
            }

        }

    }
}