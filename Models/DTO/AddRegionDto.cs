namespace WebAPICodeDemo.Models.DTO
{
    public class AddRegionDto
    {
        public string Code { get; set; }
        public string Name { get; set; }

       // public string? RegionImgURL { get; set; }
    }

    public class UpdateRegionDto
    {
      
        public string Code { get; set; }
        public string Name { get; set; }

        public string? RegionImgURL { get; set; }
    }
}
