using Website.Models;
using Website.Utils;

namespace Website.Repositories
{
    public class ProductOrderRepository : BaseRepository, IProductOrderRepository
    {
        public ProductOrderRepository(IConfiguration configuration) : base(configuration) { }

        public List<ProductOrder> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())

                {
                    cmd.CommandText = @"
                               SELECT p.Id AS ProductOrderId, p.ProductId, p.OrderId

                                FROM ProductOrder p
                                LEFT JOIN Orders up ON p.OrderId = up.id
                                ORDER BY p.OrderId
                                ";

                    var reader = cmd.ExecuteReader();

                    var productOrder = new List<ProductOrder>();
                    while (reader.Read())
                    {
                        productOrder.Add(new ProductOrder()
                        {
                            Id = DbUtils.GetInt(reader, "ProductOrderId"),
                            ProductId = DbUtils.GetInt(reader, "ProductId"),
                            OrderId = DbUtils.GetInt(reader, "OrderId"),
                           // Orders = new ()
                           // {
                              //  Id = DbUtils.GetInt(reader, "OrderId")
                           // },

                        });
                    }

                    reader.Close();
                    return productOrder;
                }
            }

        }


        public void Add(ProductOrder productOrder)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                      INSERT INTO ProductOrder ( ProductId, OrderId)
                                      OUTPUT INSERTED.ID
                                      VALUES ( @ProductId, @OrderId)
                                       "; 

                    DbUtils.AddParameter(cmd, "@ProductId", productOrder.ProductId);
                    DbUtils.AddParameter(cmd, "@OrderId", productOrder.OrderId);

                    productOrder.Id = (int)cmd.ExecuteScalar();
                }
            }
        
        }

        public void Update(ProductOrder productOrder)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                UPDATE ProductOrder
                                    
                                    SET ProductId = @ProductId, 
                                    OrderId = @OrderId
                                    WHERE ID = @ID";
                                    

                    DbUtils.AddParameter(cmd, "@Id", productOrder.Id);
                    DbUtils.AddParameter(cmd, "@ProductId", productOrder.ProductId);
                    DbUtils.AddParameter(cmd, "@OrderId", productOrder.OrderId);

                    cmd.ExecuteNonQuery();
                }
            }
        
        }


        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM ProductOrder WHERE ID = @Id";
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }

}
