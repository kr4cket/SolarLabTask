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
            _context.User.Add(value);
            _context.SaveChanges();
            return value;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(User value)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            return _context.User.Where(u => u.Id == id).FirstOrDefault()!;
        }

        public User GetByLogin(User User)
        {
            return _context.User.Where(u => u.Login == User.Login).FirstOrDefault()!;
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool IsUserExist(User User)
        {
            return !_context.User.Any(user => user.Login == User.Login && user.Password == User.Password);
        }

        public void Update(User value)
        {
            throw new NotImplementedException();
        }

        public bool IsUserLoginExist(User User)
        {
            return !_context.User.Any(user => user.Login == User.Login);
        }
    }
}
