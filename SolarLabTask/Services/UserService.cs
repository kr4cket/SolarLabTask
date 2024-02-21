using SolarLabTask.Interfaces.Repos;
using SolarLabTask.Interfaces.Services;
using SolarLabTask.Models;

namespace SolarLabTask.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        public UserService(IUserRepo repoUser)
        {
            _userRepo = repoUser;
        }

        public bool Auth(HttpContext context, User User)
        {
            if (_userRepo.IsUserExist(User))
                return false;

            User = _userRepo.GetByLogin(User);

            context.Session.SetInt32("id", User.Id);
            context.Session.SetString("login", User.Login);

            return true;
        }

        public bool Registration(HttpContext context, User User)
        {
            if (!_userRepo.IsUserLoginExist(User))
                return false;

            User = _userRepo.Add(User);
            User = _userRepo.GetByLogin(User);

            context.Session.SetInt32("id", User.Id);
            context.Session.SetString("login", User.Login);

            return true;
        }
    }
}
