using System;
using WarcraftApi.Context;
using WarcraftApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WarcraftApi.Controllers
{
    internal static class IncomeTicker
    {
        internal static async Task tryToIncomeTick(DBcontext dbcontext)
        {
            IncomeTick it = await dbcontext.IncomeTick.FirstOrDefaultAsync<IncomeTick>((x => x.Id == 1));

            DateTime now = DateTime.Now;
            DateTime lastTick = it.lastIncomeTick;

            TimeSpan ts = now - lastTick;

            int minutes = (int)Math.Floor(ts.TotalMinutes);

            if (minutes > 0)
            {
                List<Player> players = await dbcontext.Players.ToListAsync();

                //ADD resources
                foreach (Player p in players)
                {
                    p.Cash += p.Income * minutes;
                    p.Soldiers += p.SoldierIncome * minutes;
                }

                it.lastIncomeTick = now.AddSeconds(lastTick.Second);

                await dbcontext.SaveChangesAsync();
            }

        }

    }
}
