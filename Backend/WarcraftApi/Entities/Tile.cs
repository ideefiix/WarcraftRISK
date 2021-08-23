using System;
using System.ComponentModel.DataAnnotations;

namespace WarcraftApi.Entities
{
    public class Tile
    {
        [Required]
        public virtual int Id { get; set; }

        [Required]
        public virtual int PlayerId { get; set; }
        [Required]
        public virtual Player Player { get; set; }

        [Required]
        public virtual int Defence { get; set; }

        [Required]
        public virtual int WallLvl { get; set; }

        [Required]
        public virtual int VillageLvl { get; set; }

    }
}