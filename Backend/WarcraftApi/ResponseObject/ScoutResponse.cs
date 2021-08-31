using System;

namespace WarcraftApi.ResponseObject
{
    public class ScoutResponse
    {
        public int? Id { get; set; }

        public int OwnedById {get; set;}

        //The time when a territory is found
        public DateTime? scoutTime {get; set;}
    }
}