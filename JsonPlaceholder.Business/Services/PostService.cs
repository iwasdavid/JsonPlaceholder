using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JsonPlaceholder.Business.Interfaces;
using JsonPlaceholder.Business.Models;
using Microsoft.Extensions.Logging;

namespace JsonPlaceholder.Business.Services
{
    public class PostService : IPostService
    {
        private readonly IJsonPlaceholderClient _jsonPlaceholderClient;
        private readonly ILogger<PostService> _logger;

        public PostService(IJsonPlaceholderClient jsonPlaceholderClient, ILogger<PostService> logger)
        {
            _jsonPlaceholderClient = jsonPlaceholderClient;
            _logger = logger;
        }

        public Task<IEnumerable<Post>> GetPosts(string userId, int start, int take)
        {
            throw new NotImplementedException();
        }
    }
}