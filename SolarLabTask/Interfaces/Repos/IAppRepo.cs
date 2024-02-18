using SolarLabTask.Models;

namespace SolarLabTask.Interfaces.Repos
{
    public interface IAppRepo<out O, in T>
    {
        O Add(T value);
        O Update(T value);
        O Delete(int id);
        IEnumerable<O> GetAll();
    }
}
