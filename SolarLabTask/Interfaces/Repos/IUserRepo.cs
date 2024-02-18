using Microsoft.EntityFrameworkCore;
using SolarLabTask.Models;

namespace SolarLabTask.Interfaces.Repos
{
    public interface IUserRepo : IAppRepo<User, User>
    {
    }
}
