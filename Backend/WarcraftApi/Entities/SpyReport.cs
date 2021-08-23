using System;

namespace WarcraftApi.Entities
{
    public class SpyReport : IReport
    {
        public int Id { get; set; }
        public Player TargetedPlayer { get; set; }
        public Player ActionPlayer { get; set; }

        public Tile Territory {get; set;}

        public DateTime expiryDate {get; set;}

    }
}