using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WarcraftApi.Entities
{
    public class Player 
    {
        [Required]
        public virtual int Id { get; set; }
        
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string Password {get; set;}
        [Required]
        public virtual int Income { get; set; }
        [Required]
        public virtual int Cash { get; set; }
        [Required]
        public virtual int Soldiers { get; set; }
        [Required]
        public virtual int SoldierIncome { get; set; }
        [Required]
        public virtual int Score { get; set; }
        [Required]
        public virtual int ownedTerritories {get; set;}
        
    }
}