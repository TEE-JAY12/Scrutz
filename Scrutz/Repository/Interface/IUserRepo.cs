using Scrutz.Model;

namespace Scrutz.Repository.Interface
{
    public interface IUserRepo
    {
        Task<Users> FindAsync(string id);
    }
}
