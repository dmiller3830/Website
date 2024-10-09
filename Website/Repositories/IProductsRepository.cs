using Website.Models;

namespace Website.Repositories
{
    public interface IProductsRepository
    {
        void Add(Products products);
        void Delete(int id);
        List<Products> GetAll();
        void Update(Products products);
    }
}