using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WarcraftApi.Context;
using WarcraftApi.Data;
using WarcraftApi.Entities;

namespace WarcraftApi.Repositories.Interfaces
{
    public interface IPlayerRepository

    {
        Player CreatePlayer(PlayerDTO p);
        Player UpdatePlayer(PlayerDTO p);
        Player RemovePlayer(PlayerDTO p);
        Player GetPlayer(PlayerDTO p);
        Player[] GetAllPlayers();


    }
}