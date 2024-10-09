using Website.Models;

namespace Website.Repositories
{
    public interface IProductTypeRepository
    {
        void Add(ProductType productType);
        void Delete(int id);
        List<ProductType> GetAll();
        void Update(ProductType type);
    }
}