using Website.Models;
using Website.Utils;
using Microsoft.Extensions.Hosting;

namespace Website.Repositories
{
    public class ProductTypeRepository : BaseRepository, IProductTypeRepository
    {
        public ProductTypeRepository(IConfiguration configuration) : base(configuration) { }

        public List<ProductType> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                            
                            SELECT p.Id AS TypeId, p.Name AS TypeName

                              
                            FROM Type p
                            LEFT JOIN Products up ON up.TypeId = p.id
                            ORDER BY p.Name  ";

                    var reader = cmd.ExecuteReader();

                    var types = new List<ProductType>();
                    while (reader.Read())
                    {
                        types.Add(new ProductType()
                        {
                            Id = DbUtils.GetInt(reader, "TypeId"),
                            Name = DbUtils.GetString(reader, "TypeName"),


                        });
                    }
                    reader.Close();
                    return types;


                }
            }
        }



        public void Add(ProductType productType)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {

                    cmd.CommandText = @"
                                    INSERT INTO Type (Name)
                                    OUTPUT INSERTED.Id
                                    VALUES (@Name)";


                    DbUtils.AddParameter(cmd, "@Name", productType.Name);
                    productType.Id = (int)cmd.ExecuteScalar();




                }
            }
        }


        public void Update(ProductType productType)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                    UPDATE Type
                                    Set Name = @Name 
                                 
                                    WHERE Id = @Id;";
                    DbUtils.AddParameter(cmd, "@Name", productType.Name);
                    DbUtils.AddParameter(cmd, "@Id", productType.Id);

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
                    cmd.CommandText = "DELETE FROM Type WHERE ID = @Id";
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }

}


