using System.Collections.Generic;
using System.Threading.Tasks;
using JsonPlaceholder.Business.Models;

namespace JsonPlaceholder.Business.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetPosts(string userId, int start, int take);
    }
}
