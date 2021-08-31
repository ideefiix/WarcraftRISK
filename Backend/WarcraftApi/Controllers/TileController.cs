using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WarcraftApi.Context;
using WarcraftApi.Entities;
using WarcraftApi.RequestObject;
using WarcraftApi.ResponseObject;

namespace WarcraftApi.Controllers
{
    [ApiController]
    [Authorize] 
    [Route("/tile")]
    public class TileController : Controller
    {

        private readonly DBcontext _context;
        public TileController(DBcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getAllTiles()
        {

            List<Tile> tiles = await _context.Tiles.ToListAsync<Tile>();

            return Ok(tiles);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> getTile([FromRoute] int id)
        {
            
            Tile tile = await _context.Tiles.FirstOrDefaultAsync<Tile>((x => x.Id == id));

            if (tile == null) return NotFound();

            return Ok(tile);
        }

        [HttpGet("owner/{playerid:int}")]
        public async Task<IActionResult> getTilesForPlayer([FromRoute] int playerid)
        {

            Player p = await _context.Players.FirstOrDefaultAsync<Player>((x => x.Id == playerid));
            if (p == null) return NotFound();

            List<Tile> tiles = await _context.Tiles
            .Where(tile => tile.Player == p)
            .ToListAsync();

            List<TileResponse> tList = new List<TileResponse>();

            foreach (Tile t in tiles)
            {
                TileResponse tr = new TileResponse{
                    Id = t.Id,
                    Defence = t.Defence,
                    WallLvl = t.WallLvl,
                    VillageLvl = t.VillageLvl,
                };

                tList.Add(tr);
            }

            return Ok(tList);
        }



        [HttpPost]
        public async Task<IActionResult> createTile([FromBody] TileRequest tileReq)
        {
            //All newly created tiles belong to the Admin player with ID 1
            Player player = await _context.Players.FirstOrDefaultAsync<Player>((x => x.Id == 1));
            Tile tile = new Tile()
            {
                Player = player,
                Defence = tileReq.defence,
                WallLvl = tileReq.WallLvl,
                VillageLvl = tileReq.VillageLvl,
            };

            await _context.AddAsync<Tile>(tile);
            await _context.SaveChangesAsync();

            return Created("Created", tile);
        }

        [HttpPut("{id:int}/attacked")]
        public async Task<IActionResult> attackTile([FromBody] AttackRequest attack, [FromRoute] int id)
        {
            Player attacker = await _context.Players.FirstOrDefaultAsync<Player>(x => x.Id == attack.attackerId);
            Tile tile = await _context.Tiles.FirstOrDefaultAsync<Tile>(t => t.Id == id);

            if (attacker == null || tile == null) return NotFound();

            if (attack.soldiers > attacker.Soldiers) return BadRequest();

            int BattleResult = tile.Defence - attack.soldiers;
            attacker.Soldiers = attacker.Soldiers - attack.soldiers;

            if (BattleResult < 0)
            {
                tile.Player = attacker;
                tile.Defence = BattleResult * -1;
            }
            else
            {
                tile.Defence = BattleResult;
            }

            await _context.SaveChangesAsync();

            return Ok(tile);

        }

        [HttpPut("{id:int}/reinforce")]
        public async Task<IActionResult> reinforceTile([FromBody] ReinforceRequest reinforce, [FromRoute] int id)
        {
            Player reinforcer = await _context.Players.FirstOrDefaultAsync<Player>(x => x.Id == reinforce.reinforcerId);
            Tile tile = await _context.Tiles.FirstOrDefaultAsync<Tile>(t => t.Id == id);

            if (reinforcer == null || tile == null) return NotFound();

            if (reinforce.Soldiers > reinforcer.Soldiers) return BadRequest();

            if (tile.Player.Id != reinforcer.Id) return BadRequest();

            int result = tile.Defence + reinforce.Soldiers;
            reinforcer.Soldiers = reinforcer.Soldiers - reinforce.Soldiers;

            await _context.SaveChangesAsync();

            return Ok(tile);

        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> deleteTile([FromRoute] int id)
        {
            Tile oldTile = await _context.Tiles.FirstOrDefaultAsync<Tile>((x => x.Id == id));

            if (oldTile == null)
            {
                return NotFound();
            }

            _context.Tiles.Remove(oldTile);
            await _context.SaveChangesAsync();

            return Ok();
        }



    }
}