using Microsoft.EntityFrameworkCore;
using SolarLabTask.Models;

namespace SolarLabTask.Interfaces.Repos
{
    public interface IUserRepo : IAppRepo<User, User>
    {
        public bool IsUserExist(User User);
        public bool IsUserLoginExist(User User);
        public User GetByLogin(User User);
    }
}
