using Website.Models;

namespace Website.Repositories
{
    public interface IOrdersRepository
    {
        void Add(Orders orders);
        void Delete(int id);
        List<Orders> GetAll();
        void Update(Orders orders);
    }
}