using SolarLabTask.Models;

namespace SolarLabTask.Interfaces.Services
{
    public interface INearBD
    {
        public IEnumerable<Person> getNearBD(int Id, int Days);
    }
}
