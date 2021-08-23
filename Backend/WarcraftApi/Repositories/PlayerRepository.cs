using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WarcraftApi.Data;
using WarcraftApi.Entities;
using WarcraftApi.Repositories.Interfaces;

namespace WarcraftApi.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DbContext _context; 

        public PlayerRepository(DbContext context){
            _context = context;
        }
        
        public Player CreatePlayer(PlayerDTO p)
        {
            throw new System.NotImplementedException();
        }

        public Player[] GetAllPlayers()
        {
            throw new System.NotImplementedException();
        }

        public Player GetPlayer(PlayerDTO p)
        {
            throw new System.NotImplementedException();
        }

        public Player RemovePlayer(PlayerDTO p)
        {
            throw new System.NotImplementedException();
        }

        public Player UpdatePlayer(PlayerDTO p)
        {
            throw new System.NotImplementedException();
        }
    }
}