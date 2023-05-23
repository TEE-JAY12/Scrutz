using Microsoft.EntityFrameworkCore;
using Scrutz.Data;
using Scrutz.Model;
using Scrutz.Repository.Interface;

namespace Scrutz.Repository
{
    public class UserRepo: BaseRepo, IUserRepo
    {
        public UserRepo(ScrutzContext context) : base(context)
        {
        }

        public async Task<Users> FindAsync(string id)
        {
            return await _context.Users.FindAsync(id);

        }
    }
}
