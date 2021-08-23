namespace WarcraftApi.RequestObject
{
    public class PlayerRequest
    {
         public int Id { get; set; }
        
        public string Name { get; set; }
        public string Password {get; set;}
        public int Income { get; set; }
        public int Cash { get; set; }
        public int Soldiers { get; set; }
        public int SoldierIncome { get; set; }
        public int Score { get; set; }
        public int ownedTerritories {get; set;}
        public int spiesTotal {get; set;}
        public int spiesAvailable {get; set;}
    }
}