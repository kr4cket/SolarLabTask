using SolarLabTask.Models;

namespace SolarLabTask.Interfaces.Repos
{
    public interface IPersonListRepo : IAppRepo<PersonList, PersonList>
    {
        public IEnumerable<PersonList> GetListByUserId(int Id);
    }
}
