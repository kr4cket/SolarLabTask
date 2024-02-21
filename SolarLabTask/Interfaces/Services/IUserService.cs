using SolarLabTask.Models;

namespace SolarLabTask.Interfaces.Services
{
    public interface IUserService
    {
        public bool Auth(HttpContext context, User User);
        public bool Registration(HttpContext context,User User);

    }
}
