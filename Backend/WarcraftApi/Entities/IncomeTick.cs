using System;

namespace WarcraftApi.Entities
{
    public class IncomeTick
    {
        public int Id {get; set;}
        public DateTime lastIncomeTick {get; set;}
        
        //Intervall in ms
        public int TickIntervall {get; set;}
    }
}