namespace WebAPICodeDemo.Models.Domain
{
    public class Regions
    {
        public Guid ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public string? RegionImgURL { get; set; }
    }
}
