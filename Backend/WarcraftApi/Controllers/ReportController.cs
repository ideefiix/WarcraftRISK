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
    [Authorize] 
    [Route("/report")]
    public class ReportController : Controller
    {
        private readonly DBcontext _context;
        private readonly ScoutRepository _scoutRepo;
        public ReportController(DBcontext context)
        {
            _context = context;
            _scoutRepo = new ScoutRepository(context);
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

    }
}