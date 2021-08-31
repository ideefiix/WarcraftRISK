using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WarcraftApi.Context;
using WarcraftApi.Data;
using WarcraftApi.Entities;
using WarcraftApi.ResponseObject;

namespace WarcraftApi.Repositories
{
    public class ScoutRepository
    {
        private DBcontext _context;

        public ScoutRepository(DBcontext context)
        {
            _context = context;
        }


        public async Task<List<ScoutResponse>> getScoutsForPlayer(int playerid)
        {
            List<Scout> scouts = await _context.Scouts
                        .Where(s => s.OwnedBy.Id == playerid)
                        .Include("OwnedBy")
                        .ToListAsync();

            List<ScoutResponse> scoutRes = new List<ScoutResponse>();

            foreach (Scout s in scouts)
            {
                //Check if scout found Territory
                if (s.DoneScouting != null && s.DoneScouting < DateTime.Now)
                {
                    await generateSpyReport(playerid);
                    s.DoneScouting = null;
                }

                ScoutResponse sd = new ScoutResponse{
                    Id = s.Id,
                    OwnedById = s.OwnedBy.Id,
                    scoutTime = s.DoneScouting
                };
                scoutRes.Add(sd);
            }
            await _context.SaveChangesAsync();
            return scoutRes;
        }

        //Might remove the response object from here because this function is only called from getScoutsForPlayer
        // The scout tries to find an available tile 5 times
        // Then he gives up
        public async Task<SpyReportResponse> generateSpyReport(int playerid)
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
                if(srr.Territory != null){
                ScoutedTiles.Add(srr.Territory);
                }
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

                SpyReport newSpyReport = new SpyReport
                {
                    TargetedPlayer = scoutedTile.Player,
                    ActionPlayer = p,
                    Territory = scoutedTile,
                    expiryDate = DateTime.Now.AddHours(12)
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
                return srr;
            }

            // NO TILE WAS FOUND BY SCOUT
            SpyReport newSpyReport2 = new SpyReport
            {
                TargetedPlayer = null,
                ActionPlayer = p,
                Territory = null,
                expiryDate = DateTime.Now.AddHours(12)
            };

            SpyReportResponse srr2 = new SpyReportResponse
            {
                ActionPlayerId = newSpyReport2.ActionPlayer.Id,
                expiryDate = newSpyReport2.expiryDate.ToString("f"),
                Territory = null
            };

            await _context.SpyReports.AddAsync(newSpyReport2);
            await _context.SaveChangesAsync();

            return srr2;
        }

        public async Task<ScoutResponse> sendScout(int playerid)
        {
            Scout s = await _context.Scouts
            .Include("OwnedBy")
            .FirstOrDefaultAsync<Scout>((x => x.OwnedBy.Id == playerid && x.DoneScouting == null));
            if(s == null) throw new KeyNotFoundException();

            s.DoneScouting = DateTime.Now.AddHours(6);
            await _context.SaveChangesAsync();

            ScoutResponse sr = new ScoutResponse
            {
                Id = s.Id,
                OwnedById = s.OwnedBy.Id,
                scoutTime = s.DoneScouting
            };
            return sr;
        }

        public async Task<ScoutResponse> createScout(int id)
        {
            Player p = await _context.Players.FirstOrDefaultAsync<Player>((x => x.Id == id));
            if(p == null) throw new KeyNotFoundException();

            Scout s = new Scout
            {
             OwnedBy = p,
             DoneScouting = null   
            };

            ScoutResponse sr = new ScoutResponse
            {
                OwnedById = p.Id,
                scoutTime = null
            };

            await _context.Scouts.AddAsync(s);
            await _context.SaveChangesAsync();

            return sr;
        }
    }
}