using System.Threading.Tasks;
using JsonPlaceholder.Business.Clients;

namespace JsonPlaceholder.Business.Interfaces
{
    public interface IJsonPlaceholderClient
    {
        Task<JsonPlaceholderUsersResult> GetUserDtos(int start, int end);
        Task<int> GetUserPostCount(int userId);
    }
}
