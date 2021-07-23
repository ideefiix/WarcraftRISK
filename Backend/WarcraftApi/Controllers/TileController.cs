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
    [Route("/api/tile")]
    public class TileController : Controller
    {

        private readonly DBcontext _context;
        public TileController(DBcontext context){
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getAllTiles(){

           List<Tile> tiles = await _context.Tiles.ToListAsync<Tile>();

            return Ok(tiles);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> getTile([FromRoute] int id){

           Tile tile = await _context.Tiles.FirstOrDefaultAsync<Tile>((x => x.Id == id));

            if(tile == null)
            {
                return NotFound();
            }

            return Ok(tile);
        }

        

        [HttpPost]
        public async Task<IActionResult> createTile([FromBody] TileRequest tileReq)
        {

            Player player = await _context.Players.FirstOrDefaultAsync<Player>((x => x.Id == 1));
            Tile tile = new Tile(){
                OwnedBy = player,
                defence = tileReq.defence,
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

            if(attacker == null || tile == null) return NotFound();

            if(attack.minions > attacker.Minions) return BadRequest();

            

           /*  if(oldTile == null){
                return NotFound();
            }


                oldTile.OwnedBy = tileReq.OwnedBy;
                oldTile.defence = tileReq.defence;

            await _context.SaveChangesAsync(); */

            return Ok(oldTile);

        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> deleteTile([FromRoute] int id){
            Tile oldTile = await _context.Tiles.FirstOrDefaultAsync<Tile>((x => x.Id == id));

            if(oldTile == null){
                return NotFound();
            }

            _context.Tiles.Remove(oldTile);
            await _context.SaveChangesAsync();

            return Ok();
        }


        
    }
}