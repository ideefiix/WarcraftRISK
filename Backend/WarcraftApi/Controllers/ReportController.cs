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
using WarcraftApi.ResponseObject;

namespace WarcraftApi.Controllers
{
    [ApiController]
    /* [Authorize] */
    [Route("/report")]
    public class ReportController : Controller
    {
        private readonly DBcontext _context;
        public ReportController(DBcontext context)
        {
            _context = context;
        }

        [HttpGet("{playerid:int}")]
        public async Task<IActionResult> getReportsForPlayer([FromRoute] int playerid)
        {

            List<SpyReport> spyReports = await _context.SpyReports
            .Where(sr => sr.ActionPlayer.Id == playerid)
            .Include("TargetedPlayer")
            .Include("ActionPlayer")
            .Include("Territory")
            .ToListAsync();

            List<SpyReportResponse> srrList = new List<SpyReportResponse>();


            foreach (SpyReport s in spyReports)
            {
                //Remove all expired spyReports
                if (s.expiryDate < DateTime.Now)
                {
                    _context.SpyReports.Remove(s);
                    continue;
                }

                if (s.Territory == null)
                {
                    SpyReportResponse srr = new SpyReportResponse
                    {
                        SpyReportId = s.Id,
                        TargetedPlayerId = null,
                        ActionPlayerId = s.ActionPlayer.Id,
                        expiryDate = s.expiryDate.ToString("f"),
                        Territory = null
                    };
                    srrList.Add(srr);
                }
                else
                {
                    SpyReportResponse srr = new SpyReportResponse
                    {
                        SpyReportId = s.Id,
                        TargetedPlayerId = s.TargetedPlayer.Id,
                        ActionPlayerId = s.ActionPlayer.Id,
                        expiryDate = s.expiryDate.ToString("f"),
                        Territory = new TileResponse
                        {
                            Id = s.Territory.Id,
                            OwnedBy = s.Territory.Player.Name,
                            Defence = s.Territory.Defence,
                            WallLvl = s.Territory.WallLvl,
                            VillageLvl = s.Territory.VillageLvl,
                        }
                    };
                    srrList.Add(srr);
                }


            }

            await _context.SaveChangesAsync();

            return Ok(srrList);

        }

        // The scout tries to find an available tile 5 times
        // Then he gives up
        [HttpPost("spy/{playerid:int}")]
        public async Task<IActionResult> createSpyReport([FromRoute] int playerid)
        {

            Random r = new Random();
            int scoutedTileId;
            Tile scoutedTile;

            List<Tile> Ownedtiles = await _context.Tiles
            .Where(tile => tile.Player.Id == playerid)
            .ToListAsync();

            List<Tile> ScoutedTiles = new List<Tile>();

            List<SpyReport> scoutReports = await _context.SpyReports
            .Include("Territory")
            .Where(spyrep => spyrep.ActionPlayer.Id == playerid)
            .ToListAsync();

            foreach (SpyReport srr in scoutReports)
            {
                ScoutedTiles.Add(srr.Territory);
            }

            Player p = await _context.Players.FirstOrDefaultAsync((player => player.Id == playerid));

            for (int i = 0; i < 5; i++)
            {
                scoutedTileId = r.Next(1, _context.Tiles.Count() + 1);

                //CHECK IF OWN VILLAGE
                if (Ownedtiles.Any(tile => tile.Id == scoutedTileId))
                {
                    continue;
                }
                //CHECK IF ALREADY SCOUTED
                if (ScoutedTiles.Any((tile => tile.Id == scoutedTileId)))
                {
                    continue;
                }

                //GENERATE scoutReport
                scoutedTile = await _context.Tiles.Include("Player").FirstOrDefaultAsync<Tile>((t => t.Id == scoutedTileId));
                if (scoutedTile == null) return NotFound();


                if (p == null) return NotFound("Player not found");
                SpyReport newSpyReport = new SpyReport
                {
                    TargetedPlayer = scoutedTile.Player,
                    ActionPlayer = p,
                    Territory = scoutedTile,
                    expiryDate = DateTime.Now.AddHours(6)
                };

                await _context.SpyReports.AddAsync(newSpyReport);
                await _context.SaveChangesAsync();

                SpyReportResponse srr = new SpyReportResponse
                {
                    SpyReportId = newSpyReport.Id,
                    TargetedPlayerId = newSpyReport.TargetedPlayer.Id,
                    ActionPlayerId = newSpyReport.ActionPlayer.Id,
                    expiryDate = newSpyReport.expiryDate.ToString("f"),
                    Territory = new TileResponse
                    {
                        Id = scoutedTile.Id,
                        OwnedBy = scoutedTile.Player.Name,
                        Defence = scoutedTile.Defence,
                        WallLvl = scoutedTile.WallLvl,
                        VillageLvl = scoutedTile.VillageLvl,
                    }
                };
                return Ok(srr);
            }

            // NO TILE WAS FOUND BY SCOUT
            SpyReport newSpyReport2 = new SpyReport
            {
                TargetedPlayer = null,
                ActionPlayer = p,
                Territory = null,
                expiryDate = DateTime.Now.AddHours(6)
            };

            SpyReportResponse srr2 = new SpyReportResponse
            {
                ActionPlayerId = newSpyReport2.ActionPlayer.Id,
                expiryDate = newSpyReport2.expiryDate.ToString("f"),
                Territory = null
            };

            await _context.SpyReports.AddAsync(newSpyReport2);
            await _context.SaveChangesAsync();

            return Ok(srr2);
        }

    }
}