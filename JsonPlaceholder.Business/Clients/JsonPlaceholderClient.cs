using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using JsonPlaceholder.Business.Interfaces;
using JsonPlaceholder.Business.Models;

namespace JsonPlaceholder.Business.Clients
{
    public record JsonPlaceholderUsersResult(bool Success, IEnumerable<UserDto> Users);

    public class JsonPlaceholderClient : IJsonPlaceholderClient
    {
        private readonly HttpClient _client;

        public JsonPlaceholderClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<JsonPlaceholderUsersResult> GetUserDtos(int start, int end)
        {
            var response = await _client.GetAsync($"users?_start={start}&_limit={end}");

            if(response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var users = JsonSerializer.Deserialize<IEnumerable<UserDto>>(json);
                return new JsonPlaceholderUsersResult(true, users);
            }
            return new JsonPlaceholderUsersResult(false, null);
        }

        public async Task<int> GetUserPostCount(int userId)
        {
            var response = await _client.GetAsync($"posts?userId={userId}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var posts = JsonSerializer.Deserialize<IEnumerable<PostDto>>(json);
                return posts.Count();
            }

            return 0;
        }
    }
}
