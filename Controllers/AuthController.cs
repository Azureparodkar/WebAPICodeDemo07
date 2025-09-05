using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WebAPICodeDemo.Models.DTO;
using Microsoft.IdentityModel.Tokens;
using WebAPICodeDemo.Repositries;

namespace WebAPICodeDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepositry tokenRepositry;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepositry tokenRepositry)
        {
            this._userManager = userManager;
            this.tokenRepositry = tokenRepositry;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterNewuserDto registerNewuserDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerNewuserDto.UserName,
                Email = registerNewuserDto.UserName

            };

            var identityRes = await _userManager.CreateAsync(identityUser, registerNewuserDto.Password);
            if (identityRes.Succeeded)
            {
                if (registerNewuserDto.Roles != null && registerNewuserDto.Roles.Any())

                    //identityRes = await _userManager.AddToRoleAsync(identityUser, registerNewuserDto.Roles);
                    identityRes = await _userManager.AddToRolesAsync(identityUser, registerNewuserDto.Roles);

                if (identityRes.Succeeded)
                {
                    return Ok("User was registered ||");
                }

            }
            return BadRequest("went wrong");

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Username);
            if(user!=null)
            {
               var checkpassword=  await _userManager.CheckPasswordAsync(user, loginDto.Password);
                if(checkpassword)
                {
                    //create token 
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                        var Jwttoken = tokenRepositry.CreateToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            Jwttoken = Jwttoken
                        };
                        return Ok(response);
                    }
                   

                }


            }

            return BadRequest("Incorrect");



        }
    }
}
