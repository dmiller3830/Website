using Microsoft.Extensions.Hosting;
using Website.Models;
using Website.Utils;

namespace Website.Repositories
{
    public class ProductsRepository : BaseRepository, IProductsRepository
    {
        public ProductsRepository(IConfiguration configuration) : base(configuration) { }

        public List<Products> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"

                SELECT p.Id as ProductId,  p.Name, p.Price, p.TypeId, 

                     up.Name as TypeName, up.Id
                    FROM Products p
                    LEFT JOIN Type up ON p.TypeId = up.id
                ORDER BY  p.Name";

                    var reader = cmd.ExecuteReader();

                    var products = new List<Products>();
                    while (reader.Read())
                    {
                        products.Add(new Products()
                        {
                            Id = DbUtils.GetInt(reader, "ProductId"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Price = DbUtils.GetInt(reader, "Price"),
                            TypeId = DbUtils.GetInt(reader, "TypeId"),
                            Type = new ProductType()
                            {
                                Id = DbUtils.GetInt(reader, "TypeId"),
                                Name = DbUtils.GetString(reader, "TypeName"),
                            },
                        });

                    }

                    reader.Close();

                    return products;
                }
            }
        }


        public void Add(Products products)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {

                    cmd.CommandText = @"
                                INSERT INTO Products (Name, Price, TypeId)
                                OUTPUT INSERTED.ID
                                VALUES (@Name, @Price, @TypeId)
                                ";
                    DbUtils.AddParameter(cmd, "@Name", products.Name);
                    DbUtils.AddParameter(cmd, "@Price", products.Price);
                    DbUtils.AddParameter(cmd, "@TypeId", products.TypeId);

                    products.Id = (int)cmd.ExecuteScalar();

                }
            }
        }


        public void Update(Products products)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                UPDATE Products
                                SET Name = @Name, 
                                    Price = @Price, 
                                    TypeId = @TypeId
                                WHERE Id = @Id";

                    DbUtils.AddParameter(cmd, "@Name", products.Name);
                    DbUtils.AddParameter(cmd, "@Price", products.Price);
                    DbUtils.AddParameter(cmd, "@TypeId", products.TypeId);
                    DbUtils.AddParameter(cmd, "@Id", products.Id);

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
                    cmd.CommandText = "DELETE FROM Products WHERE ID = @Id";
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }





    }
}
