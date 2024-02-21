using SolarLabTask.Models;

namespace SolarLabTask.Interfaces.Repos
{
    public interface IAppRepo<out O, in T>
    {
        O Get(int id);
        O Add(T value);
        void Update(T value);
        void Delete(T value);
        IEnumerable<O> GetAll();
    }
}
