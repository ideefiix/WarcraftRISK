using WarcraftApi.Context;
using System;
using System.Linq;
using WarcraftApi.Entities;

namespace WarcraftApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DBcontext context){
            context.Database.EnsureCreated();

            if (context.Players.Any()){
                return ;
            }

            var players = new Player[]{
                new Player{Name="Fille",Income=10,Cash=100,Minions=2,Spawner=1,Score=0},
                new Player{Name="Emill",Income=5,Cash=100,Minions=5,Spawner=1,Score=0}
            };

            foreach (Player p in players)
            {
                context.Players.Add(p);
            }

            var Tiles = new Tile[]{
                new Tile{OwnedBy=players[0],defence=27},
                new Tile{OwnedBy=players[0],defence=50},
                new Tile{OwnedBy=players[0],defence=63}
            };

            foreach (Tile t in Tiles){
                context.Tiles.Add(t);
            }

            context.SaveChanges();

        }
    }
}