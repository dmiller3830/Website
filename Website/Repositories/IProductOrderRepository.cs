using Website.Models;

namespace Website.Repositories
{
    public interface IProductOrderRepository
    {

        public void Add(ProductOrder productOrder);

        public void Update(ProductOrder productOrder);

        public void Delete(int id);  


        List<ProductOrder> GetAll();
    }
}