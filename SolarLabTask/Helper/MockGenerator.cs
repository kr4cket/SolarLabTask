using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SolarLabTask.DataBase;
using SolarLabTask.Models;
using System.Xml.Linq;

namespace SolarLabTask.Helper
{
    public class MockGenerator
    {
        private WebAppContext _context;
        public MockGenerator ()
        {
            var builder = new ConfigurationBuilder();
            var dir = Directory.GetCurrentDirectory().ToString();
            builder.SetBasePath(dir);
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<WebAppContext>();

            _context = new WebAppContext(optionsBuilder.UseNpgsql(connectionString).Options);

        }
        public void MakeRecords()
        {
            return;
            //if (_context.User.Any())
            //{
            //    return;
            //}

            var ImageObj = new PersonImage()
            {
                Name = "default",
                Path = "default.png",
            };

            List<string> categories = new List<string>() { "Друг/Подруга", "Коллега", "Семья" };
            List<string> names = new List<string>() { "Иван", "Петр", "Василий", "Григорий" };
            List<string> surnames = new List<string>() { "Иванов", "Петров", "Васильев", "Григорьев" };
            List<DateOnly> BD = new List<DateOnly>() {
                new DateOnly(2000, 3, 21),
                new DateOnly(1994, 2, 22),
                new DateOnly(2003, 10, 21),
                new DateOnly(1991, 2, 24)
            };

            List<PersonCategory> ctgs = new();
            for (int i = 0; i < 3; i++)
            {
                PersonCategory temp = new PersonCategory()
                {
                    Name = categories[i],
                };
                ctgs.Add(temp);
            }

            User user = new() { Login = "admin", Password = "admin" };
            List<Person> list = new List<Person>();

            for (int i = 0; i < 4; i++)
            {
                Person temp = new Person() {
                    Name = names[i],
                    Surname = surnames[i],
                    UserId = 1,
                    DateOfBirth = BD[i],
                    CategoryId = i,
                    PersonCategory = ctgs[0],
                    User = user,
                    Image = ImageObj,
                };
                list.Add(temp);
            }

            _context.PersonImage.Add(ImageObj);
            _context.PersonCategory.AddRange(ctgs);
            _context.User.Add(user);
            _context.Person.AddRange(list);
            _context.SaveChanges();
        }
    }
}
