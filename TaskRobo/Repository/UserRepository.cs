using System;
using TaskRobo.Models;

namespace TaskRobo.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly TaskDbContext context;
        public UserRepository(TaskDbContext _context)
        {
            context = _context;
        }

        // This method should be used to save user details into database
        public int CreateUser(AppUser user)
        {
            context.AppUsers.Add(user);
            context.SaveChanges();
            return 1;
        }

        // This method should be used to return boolean value. If user is authenticated successfully it should return true else return false
        public bool IsAuthenticated(AppUser user)
        {
            return true;
        }
    }
}