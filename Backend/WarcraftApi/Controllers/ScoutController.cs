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
using WarcraftApi.Repositories;
using WarcraftApi.RequestObject;
using WarcraftApi.ResponseObject;

namespace WarcraftApi.Controllers
{
    [ApiController]
    /* [Authorize] */
    [Route("/scout")]
    public class ScoutController : Controller
    {
        private readonly DBcontext _context;
        private readonly ScoutRepository _scoutRepo;
        public ScoutController(DBcontext context)
        {
            _context = context;
            _scoutRepo = new ScoutRepository(_context);
        }

        [HttpGet("get/{playerid:int}")]
        public async Task<IActionResult> getScoutsForPlayer([FromRoute] int playerid)
        {
            List<ScoutResponse> sr = await _scoutRepo.getScoutsForPlayer(playerid);
            return Ok(sr);
        }

        [HttpPost("create/{playerid:int}")]
        public async Task<IActionResult> createScoutForPlayer([FromRoute] int playerid)
        {
            try
            {
                ScoutResponse sr = await _scoutRepo.createScout(playerid);
                return Ok(sr);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Player not found");
            }
            catch (Exception)
            {
                return BadRequest();
            }


        }

        [HttpPut("send/{playerid:int}")]

        public async Task<IActionResult> sendScoutForPlayer([FromRoute] int playerid)
        {
            try {
            ScoutResponse sr = await _scoutRepo.sendScout(playerid);
            return Ok(sr);
            }
            catch(KeyNotFoundException){
                return NotFound("Found no available scouts for the player");
            }
            
        }

    }
}