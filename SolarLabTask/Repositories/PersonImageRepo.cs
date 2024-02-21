using SolarLabTask.DataBase;
using SolarLabTask.Interfaces.Repos;
using SolarLabTask.Models;

namespace SolarLabTask.Repositories
{
    public class PersonImageRepo : IPersonImageRepo
    {
        private WebAppContext _context;
        public PersonImageRepo(WebAppContext context)
        {
            _context = context;
        }
        public PersonImage Add(PersonImage value)
        {
            _context.Add(value);
            _context.SaveChanges();
            return value;
        }

        public void Delete(PersonImage value)
        {
            throw new NotImplementedException();
        }

        public PersonImage Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PersonImage> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(PersonImage value)
        {
            throw new NotImplementedException();
        }
    }
}
