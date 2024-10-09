using Website.Models;
using Website.Utils;

namespace Website.Repositories
{
    public class OrdersRepository : BaseRepository, IOrdersRepository
    {

        public OrdersRepository(IConfiguration configuration) : base(configuration) { }

        public List<Orders> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT p.Id as OrderId, p.Date, p.UserId AS OrderUserId, p.Total,

                                    up.Id AS UserId, up.Name
                                    FROM Orders p
                                LEFT JOIN [User] up ON p.UserId = up.id
                                ORDER BY p.Date";

                    var reader = cmd.ExecuteReader();

                    var orders = new List<Orders>();
                    while (reader.Read())
                    {
                        orders.Add(new Orders()
                        {

                            Id = DbUtils.GetInt(reader, "OrderId"),
                            date = DbUtils.GetDateTime(reader, "Date"),
                            userId = DbUtils.GetInt(reader, "UserId"),
                            Total = DbUtils.GetInt(reader, "Total"),
                        });

                    }

                    reader.Close();

                    return orders;
                }

            }
        }


        public void Add(Orders orders)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                       INSERT INTO Orders (Date, UserId, Total)
                                        OUTPUT INSERTED.ID
                                        VALUES (@Date, @UserId, @Total)"; 

                    DbUtils.AddParameter(cmd, "@Date", orders.date);
                    DbUtils.AddParameter(cmd, "@UserId", orders.userId);
                    DbUtils.AddParameter(cmd, "@Total", orders.Total);

                    orders.Id = (int)cmd.ExecuteScalar();
                
                }
            }

        }

        public void Update(Orders orders)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                UPDATE Orders
                                    SET Date = @Date, 
                                        UserId = @UserId,
                                        Total = @Total
                                        WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@Date", orders.date);
                    DbUtils.AddParameter(cmd, "@UserId", orders.userId);
                    DbUtils.AddParameter(cmd, "@Total", orders.Total);
                    DbUtils.AddParameter(cmd, "@Id", orders.Id);

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
                    cmd.CommandText = "DELETE FROM Orders WHERE ID = @Id"; 
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery ();

                }
            }
        }

       

    }

}
