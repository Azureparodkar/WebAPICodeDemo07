namespace WebAPICodeDemo.Models.Domain
{
    public class walkz
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double  LengthInkm { get; set; }
        public string? WalkImgUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionID { get; set; }
        public Difficulty Difficulty { get; set; }
        public Regions Regions { get; set; }    
    }
}
