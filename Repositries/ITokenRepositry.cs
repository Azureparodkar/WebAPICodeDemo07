using Microsoft.AspNetCore.Identity;

namespace WebAPICodeDemo.Repositries
{
    public interface ITokenRepositry
    {
        string CreateToken(IdentityUser user, List<string> ROles);
    }
}
