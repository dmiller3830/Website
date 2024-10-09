using System.Security.Cryptography;
using Website.Models;
using Website.Utils;

namespace Website.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration) { }

        public List<User> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        
                                SELECT p.Id UserId, p.Name, p.Email, p.Password, p.ShippingAddress, 

                                up.Id AS OrderId, up.Total
                                FROM [User] p
                                LEFT JOIN Orders up ON p.Id = up.UserId
                                ORDER BY p.Name";

                    var reader = cmd.ExecuteReader();

                    var user = new List<User>();
                    while (reader.Read())
                    {
                        user.Add(new User()
                        {
                            Id = DbUtils.GetInt(reader, "UserId"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Email = DbUtils.GetString(reader, "Email"),
                            Password = DbUtils.GetString(reader, "Password"),
                            ShippingAddress = DbUtils.GetString(reader, "ShippingAddress"),


                        });

                    }
                    reader.Close();
                    return user;

                }
            }

        }




        public void Add(User user)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                               INSERT INTO [User] (Name, Email, Password, ShippingAddress)
                                OUTPUT INSERTED.ID
                                VALUES (@Name, @Email, @Password, @ShippingAddress)";

                    DbUtils.AddParameter(cmd, "@Name", user.Name);
                    DbUtils.AddParameter(cmd, "@Email", user.Email);
                    DbUtils.AddParameter(cmd, "@Password", user.Password);
                    DbUtils.AddParameter(cmd, "@ShippingAddress", user.ShippingAddress);

                    user.Id = (int)cmd.ExecuteScalar();

                }
            }
        }


        public void Update(User user)
        {
            using (var conn = Connection)

            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                UPDATE [User]
                                SET Name = @Name, 
                                    Email = @Email, 
                                    Password = @Password, 
                                    ShippingAddress = @ShippingAddress
                                    WHERE Id = @Id";

                    DbUtils.AddParameter(cmd, "@Name", user.Name);
                    DbUtils.AddParameter(cmd, "@Email", user.Email);
                    DbUtils.AddParameter(cmd, "@Password", user.Password);
                    DbUtils.AddParameter(cmd, "@ShippingAddress", user.ShippingAddress);
                    DbUtils.AddParameter(cmd, "@Id", user.Id);
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
                    cmd.CommandText = "DELETE FROM [User] WHERE ID = @Id";
                    DbUtils.AddParameter(cmd, "id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }

}
