using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZuzexTestProject.Domain.Model;
using ZuzexTestProject.Infrastructure.DTO;

namespace ZuzexTestProject.Infrastructure.Services
{
    public interface IPostsService
    {
        Task<IEnumerable<Post>> GetAllPostsAsync(int? offset, int? limit);

        Task<Post> GetPostDetailAsync(int id);

        Task<Post> CreatePostAsync(CreatePostDTO postDTO);

        Task UpdatePostAsync(int id, CreatePostDTO postDTO);

        Task RemovePostAsync(int id);
    }
}
