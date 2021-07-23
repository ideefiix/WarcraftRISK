namespace WarcraftApi.RequestObject
{
    public class PlayerRequest
    {
         public int Id { get; set; }
        
        public string Name { get; set; }
        public int Income { get; set; }
        public int Cash { get; set; }
        public int Minions { get; set; }
        public int Spawner { get; set; }
        public int Score { get; set; }
    }
}