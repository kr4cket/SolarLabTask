using SolarLabTask.Interfaces.Repos;
using SolarLabTask.Interfaces.Services;
using SolarLabTask.Models;
using SolarLabTask.Repositories;

namespace SolarLabTask.Services
{
    public class PersonListService : IPersonListService
    {
        private readonly IPersonListRepo _repo;
        public PersonListService(IPersonListRepo repo) 
        {
            _repo = repo;
        }
        public IEnumerable<PersonList> getNearBD(int Id, int Days)
        {
            var list = _repo.GetListByUserId(Id);
            var firstDate = DateOnly.FromDateTime(DateTime.Today).DayOfYear;
            var secondDate = DateOnly.FromDateTime(DateTime.Today.AddDays(Days)).DayOfYear;

            return list.Where(x => x.Person.DateOfBirth.DayOfYear >= firstDate && x.Person.DateOfBirth.DayOfYear < secondDate).ToList();
        }
    }
}
