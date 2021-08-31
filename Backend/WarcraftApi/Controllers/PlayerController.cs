using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WarcraftApi.Context;
using WarcraftApi.Entities;
using WarcraftApi.RequestObject;

namespace WarcraftApi.Controllers
{

    [ApiController]
    /* [Authorize] */
    [Route("/player")]
    public class PlayerController : Controller
    {

        private readonly DBcontext _context;

        public PlayerController(DBcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getPlayers()
        {
           await IncomeTicker.tryToIncomeTick(_context); 

            List<Player> players = await _context.Players.ToListAsync<Player>();

            return Ok(players);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> getPlayer([FromRoute] int id)
        {
            await IncomeTicker.tryToIncomeTick(_context); 

            Player p = await _context.Players.FirstOrDefaultAsync<Player>((x => x.Id == id));
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> createPlayer([FromBody] PlayerRequest playerReq)
        {
            var newPlayer = new Player
            {
                Name = playerReq.Name,
                Password = playerReq.Password,
                Income = playerReq.Income,
                Cash = playerReq.Cash,
                Soldiers = playerReq.Soldiers,
                SoldierIncome = playerReq.SoldierIncome,
                Score = playerReq.Score,
                ownedTerritories = playerReq.ownedTerritories
            };

            await _context.Players.AddAsync(newPlayer);
            _context.SaveChanges();

            return Ok(newPlayer);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> deletePlayer([FromRoute] int id)
        {
            Player p = await _context.Players.FirstOrDefaultAsync<Player>((x => x.Id == id));
            if (p == null)
            {
                return NotFound();
            }
            _context.Players.Remove(p);
            await _context.SaveChangesAsync();
            return Ok();

        }

        // Updates everything except Name and Password
        [HttpPut("{id:int}")]
        public async Task<IActionResult> updatePlayer([FromRoute] int id, [FromBody] PlayerRequest playerreq)
        {
            await IncomeTicker.tryToIncomeTick(_context); 
            
            Player p = await _context.Players.FirstOrDefaultAsync<Player>((x => x.Id == id));
            if (p == null)
            {
                return NotFound();
            }
            p.Income = playerreq.Income;
            p.Cash = playerreq.Cash;
            p.Soldiers = playerreq.Soldiers;
            p.SoldierIncome = playerreq.SoldierIncome;
            p.Score = playerreq.Score;
            p.ownedTerritories = playerreq.ownedTerritories;

            await _context.SaveChangesAsync();

            return Ok(p);

        }
    }
}