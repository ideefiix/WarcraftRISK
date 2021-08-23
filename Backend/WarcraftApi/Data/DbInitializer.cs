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
                new Player{Id=1,Name="Fille",Password="lol",Income=10,Cash=100,Soldiers=2,SoldierIncome=1,Score=0,ownedTerritories=3,spiesTotal=1,spiesAvailable=1},
                new Player{Id=2,Name="Emil",Password="lol",Income=5,Cash=100,Soldiers=5,SoldierIncome=1,Score=0,ownedTerritories=0,spiesTotal=1,spiesAvailable=1}
            };

            foreach (Player p in players)
            {
                context.Players.Add(p);
            }

            var Tiles = new Tile[]{
                new Tile{Player=players[0],Defence=27, WallLvl=1,VillageLvl=1},
                new Tile{Player=players[0],Defence=50, WallLvl=1,VillageLvl=1},
                new Tile{Player=players[0],Defence=63, WallLvl=1,VillageLvl=1},
                new Tile{Player=players[1],Defence=34, WallLvl=1,VillageLvl=1},
                new Tile{Player=players[1],Defence=5, WallLvl=1,VillageLvl=1}
            };

            foreach (Tile t in Tiles){
                context.Tiles.Add(t);
            }

            context.SaveChanges();

        }
    }
}