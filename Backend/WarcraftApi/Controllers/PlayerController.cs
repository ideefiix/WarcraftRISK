using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WarcraftApi.Context;
using WarcraftApi.Entities;
using WarcraftApi.RequestObject;

namespace WarcraftApi.Controllers
{

    [ApiController]
    [Route("/api/player")]
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
            List<Player> players = await _context.Players.ToListAsync<Player>();

            return Ok(players);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> getPlayer([FromRoute] int id)
        {
            Player p = await _context.Players.FirstOrDefaultAsync<Player>((x => x.Id == id));
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
        }

        [HttpPost]
        public async Task<IActionResult> createPlayer([FromBody] PlayerRequest playerReq)
        {
            var newPlayer = new Player
            {
                Name = playerReq.Name,
                Income = playerReq.Income,
                Cash = playerReq.Cash,
                Minions = playerReq.Minions,
                Spawner = playerReq.Spawner,
                Score = playerReq.Score
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

        [HttpPut("{id:int}")]
        public async Task<IActionResult> updatePlayer([FromRoute] int id, [FromBody] PlayerRequest playerreq)
        {
            Player p = await _context.Players.FirstOrDefaultAsync<Player>((x => x.Id == id));
            if (p == null)
            {
                return NotFound();
            }

            p.Name = playerreq.Name;
            p.Income = playerreq.Income;
            p.Cash = playerreq.Cash;
            p.Minions = playerreq.Minions;
            p.Spawner = playerreq.Spawner;
            p.Score = playerreq.Score;

            await _context.SaveChangesAsync();

            return Ok(p);

        }
    }
}