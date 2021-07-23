using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WarcraftApi.Context;
using WarcraftApi.Entities;

namespace WarcraftApi.Repositories.Interfaces
{
    public interface IplayerRepository 

    {
        public Player AddPlayer(Player p);
        public Player RemovePlayer(Player p);
         
    }
}