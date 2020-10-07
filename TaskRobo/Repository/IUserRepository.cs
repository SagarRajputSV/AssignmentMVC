using TaskRobo.Models;

namespace TaskRobo.Repository
{
    public interface IUserRepository
    {
        int CreateUser(AppUser user);
        bool IsAuthenticated(AppUser user);
    }
}