using Microsoft.Extensions.Configuration.UserSecrets;

namespace Website.Models
{
    public class BlogPosts
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string content { get; set; }

        public DateTime postdate { get; set; }

        public int userId { get; set; }

    }
}
