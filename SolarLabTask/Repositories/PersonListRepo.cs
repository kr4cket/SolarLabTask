using Microsoft.EntityFrameworkCore;
using SolarLabTask.DataBase;
using SolarLabTask.Interfaces.Repos;
using SolarLabTask.Models;

namespace SolarLabTask.Repositories
{
    public class PersonListRepo : IPersonListRepo
    {

        private WebAppContext _context;
        public PersonListRepo(WebAppContext context)
        {
            _context = context;
        }

        public PersonList Add(PersonList value)
        {
            throw new NotImplementedException();
        }

        public PersonList Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PersonList> GetListByUserId(int Id)
        {
            return _context.PersonList.Where(list => list.UserId == Id).Include(list => list.Person).Include(list => list.PersonCategory).ToList();
        }

        public IEnumerable<PersonList> GetAll()
        {
            throw new NotImplementedException();
        }

        public PersonList Update(PersonList value)
        {
            throw new NotImplementedException();
        }
    }
}
