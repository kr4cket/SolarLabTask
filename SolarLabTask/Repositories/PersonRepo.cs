using Microsoft.EntityFrameworkCore;
using SolarLabTask.DataBase;
using SolarLabTask.Interfaces.Repos;
using SolarLabTask.Models;
using System.Collections.Generic;

namespace SolarLabTask.Repositories
{
    public class PersonRepo : IPersonRepo
    {
        private WebAppContext _context;
        public PersonRepo(WebAppContext context)
        {
            _context = context;
        }
        public Person Add(Person value)
        {
            _context.Add(value);
            _context.SaveChanges();
            return value;
        }

        public void Delete(Person value)
        {
            _context.Remove(value);
            _context.SaveChanges();
        }

        public Person Get(int id)
        {
            return _context.Person.Where(p => p.Id == id).Include(i => i.Image).Include(c => c.PersonCategory).FirstOrDefault()!;
        }

        public IEnumerable<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public PersonImage GetImageById(int Id)
        {
            return _context.PersonImage.
                Where(p => p.Id == _context.Person.
                Where(p => p.Id == Id).FirstOrDefault().ImageId).
                FirstOrDefault();
        }

        public IEnumerable<Person> GetListByUserId(int Id)
        {
            return _context.Person.Where(list => list.UserId == Id).Include(list => list.PersonCategory).Include(img => img.Image).ToList();
        }

        public void Update(Person value)
        {
            _context.Person.Update(value);
            _context.SaveChanges();
        }
    }
}
