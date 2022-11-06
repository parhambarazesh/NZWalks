namespace NZWalksApi.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }= null!;
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }

        // Navigation properties
        public Region Region { get; set; }= null!;
        public WalkDifficulty WalkDifficulty { get; set; }= null!;
    }
}