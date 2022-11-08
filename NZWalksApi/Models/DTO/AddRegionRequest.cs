namespace NZWalksApi.Models.DTO
{
    public class AddRegionRequest
    {
        public string Code { get; set; }= null!;
        public string Name { get; set; }= null!;
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long Population { get; set; }
    }
}