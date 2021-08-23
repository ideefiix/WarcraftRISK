using WarcraftApi.Entities;

namespace WarcraftApi.RequestObject
{
    public class TileRequest 
    {

         public int Id {get; set;}
        /* public int OwnedByPlayerId { get; set; } */
        public int defence { get; set; }
        public int WallLvl { get; set; }
        public int VillageLvl { get; set; }
    }
}