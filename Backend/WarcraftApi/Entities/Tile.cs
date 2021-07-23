namespace WarcraftApi.Entities
{
    public class Tile
    {
        public int Id {get; set;}

        public Player OwnedBy {get; set;}
        public int defence {get; set;}
    }
}