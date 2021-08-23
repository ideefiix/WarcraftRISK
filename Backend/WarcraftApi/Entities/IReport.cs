namespace WarcraftApi.Entities
{
    public interface IReport
    {
        int Id { get; set; }
        Player TargetedPlayer { get; set; }
        Player ActionPlayer { get; set; }
    }
}