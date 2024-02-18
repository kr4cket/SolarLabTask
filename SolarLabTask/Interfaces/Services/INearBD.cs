using SolarLabTask.Models;

namespace SolarLabTask.Interfaces.Services
{
    public interface INearBD
    {
        public IEnumerable<PersonList> getNearBD(int Id, int Days);
    }
}
