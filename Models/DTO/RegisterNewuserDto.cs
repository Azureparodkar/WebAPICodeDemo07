using System.ComponentModel.DataAnnotations;

namespace WebAPICodeDemo.Models.DTO
{
    public class RegisterNewuserDto
    {

        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName {  get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string[] Roles { get; set; }
    }
}
