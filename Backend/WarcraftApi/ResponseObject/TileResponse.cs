using System;

namespace WarcraftApi.ResponseObject
{
    public class TileResponse
    {
        
        public int Id { get; set; }

        public string OwnedBy {get; set;}

        public int Defence { get; set; }

        public int WallLvl { get; set; }

        public int VillageLvl { get; set; }

        //Conquered.ToString("f") on Tile property
    }
}