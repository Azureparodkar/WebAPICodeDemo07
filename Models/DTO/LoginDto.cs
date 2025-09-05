using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebAPICodeDemo.Models.DTO
{
    public class LoginDto
    {
        [Required]
        [DataType(DataType.EmailAddress) ]
        public string Username { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
