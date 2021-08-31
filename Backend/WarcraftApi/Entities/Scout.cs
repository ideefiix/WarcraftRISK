using System;

namespace WarcraftApi.Entities
{
    public class Scout
    {
        public int Id { get; set; }
        public Player OwnedBy { get; set; }

        public DateTime? DoneScouting {get; set;}
    }
}