using Microsoft.EntityFrameworkCore;
using SolarLabTask.DataBase;
using SolarLabTask.Interfaces.Repos;
using SolarLabTask.Models;

namespace SolarLabTask.Services
{
    public class UserRepo: IUserRepo
    {
        private WebAppContext _context; 
        public UserRepo(WebAppContext context) 
        {
            _context = context;
        }

        public User Add(User value)
        {
            throw new NotImplementedException();
        }

        public User Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Update(User value)
        {
            throw new NotImplementedException();
        }
    }
}
