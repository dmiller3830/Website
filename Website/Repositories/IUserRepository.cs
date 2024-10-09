using Website.Models;

namespace Website.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        void Delete(int id);
        List<User> GetAll();
        void Update(User user);
    }
}