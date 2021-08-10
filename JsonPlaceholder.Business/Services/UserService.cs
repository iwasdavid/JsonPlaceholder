using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonPlaceholder.Business.Interfaces;
using JsonPlaceholder.Business.Models;
using Microsoft.Extensions.Logging;

namespace JsonPlaceholder.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IJsonPlaceholderClient _jsonPlaceholderClient;
        private readonly ILogger<UserService> _logger;

        public UserService(IJsonPlaceholderClient jsonPlaceholderClient, ILogger<UserService> logger)
        {
            _jsonPlaceholderClient = jsonPlaceholderClient;
            _logger = logger;
        }

        public async Task<IEnumerable<User>> GetUsers(int start, int take)
        {
            var usersResult = await _jsonPlaceholderClient.GetUserDtos(start, take);

            if(usersResult.Success)
            {
                var users = await Task.WhenAll(usersResult.Users.Select(async user => new User {
                    Name = user.Name,
                    UserName = user.UserName,
                    PostCount = await GetPostCountForUserId(user.Id)
                }));

                return users;
            }

            return null;
        }

        private async Task<int> GetPostCountForUserId(int userId)
        {
            return await _jsonPlaceholderClient.GetUserPostCount(userId);
        }
    }
}
