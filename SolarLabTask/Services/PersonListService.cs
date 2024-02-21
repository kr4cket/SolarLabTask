using SolarLabTask.Interfaces.Repos;
using SolarLabTask.Interfaces.Services;
using SolarLabTask.Models;
using SolarLabTask.Repositories;

namespace SolarLabTask.Services
{
    public class PersonListService : IPersonListService
    {
        private readonly IPersonRepo _repo;
        public PersonListService(IPersonRepo repo) 
        {
            _repo = repo;
        }
        public IEnumerable<Person> getNearBD(int Id, int Days)
        {
            var list = _repo.GetListByUserId(Id);
            var firstDate = DateOnly.FromDateTime(DateTime.Today).DayOfYear;
            var secondDate = DateOnly.FromDateTime(DateTime.Today.AddDays(Days)).DayOfYear;

            return list.Where(x => x.DateOfBirth.DayOfYear >= firstDate && x.DateOfBirth.DayOfYear < secondDate).ToList();
        }

    }
}
