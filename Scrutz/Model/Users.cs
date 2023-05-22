using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scrutz.Model
{
    public class Users
    {
        [Key] // Specify the primary key attribute
        [MinLength(30)]
        public string UserID { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [StringLength(150)]
        public string Image_URL { get; set; }

        public bool IsVerified { get; set; }

        public int FollowersCount { get; set; }

        public int FollowingCount { get; set; }

        public int TweetCount { get; set; }

        public int ListedCount { get; set; }

        public DateTime CreateDate { get; set; }

       public ICollection<Tweets> Tweets { get; set; }
    }
}
