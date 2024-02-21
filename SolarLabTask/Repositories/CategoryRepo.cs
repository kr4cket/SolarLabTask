using SolarLabTask.DataBase;
using SolarLabTask.Interfaces.Repos;
using SolarLabTask.Models;

namespace SolarLabTask.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private WebAppContext _context;
        public CategoryRepo(WebAppContext context)
        {
            _context = context;
        }
        public PersonCategory Add(PersonCategory value)
        {
            throw new NotImplementedException();
        }

        public void Delete(PersonCategory value)
        {
            throw new NotImplementedException();
        }

        public PersonCategory Get(int id)
        {
            return _context.PersonCategory.Where(c => c.Id == id).FirstOrDefault();
        }

        public IEnumerable<PersonCategory> GetAll()
        {
            return _context.PersonCategory.ToList();
        }

        public void Update(PersonCategory value)
        {
            throw new NotImplementedException();
        }
    }
}
