using System.Collections.Generic;
using System.Threading.Tasks;
using JsonPlaceholder.Business.Models;

namespace JsonPlaceholder.Business.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers(int start, int take);
    }
}
