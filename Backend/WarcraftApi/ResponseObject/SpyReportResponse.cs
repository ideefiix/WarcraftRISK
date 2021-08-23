namespace WarcraftApi.ResponseObject
{
    public class SpyReportResponse
    {
        public int SpyReportId { get; set; }
        public int? TargetedPlayerId { get; set; }
        public int ActionPlayerId { get; set; }

        public string expiryDate {get; set;}

        public TileResponse Territory {get; set;}
    }
}