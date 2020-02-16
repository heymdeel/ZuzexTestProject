using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZuzexTestProject.Domain.Model;
using ZuzexTestProject.Infrastructure.DTO;
using ZuzexTestProject.Infrastructure.Services;
using ZuzexTestProject.UI.ViewModels;

namespace ZuzexTestProject.UI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsService postsService;
        private readonly IMapper mapper;

        public PostsController(IPostsService postsService, IMapper mapper)
        {
            this.postsService = postsService;
            this.mapper = mapper;
        }

        // GET: api/posts
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PostsListVM>), 200)]
        public async Task<ActionResult<IEnumerable<PostsListVM>>> GetPosts()
        {
            var posts = await postsService.GetAllPostsAsync();
            var postsVM = mapper.Map<IEnumerable<PostsListVM>>(posts);

            return Ok(postsVM);
        }

        // GET: api/posts/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Post), 200)]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await postsService.GetPostDetailAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, [FromBody]CreatePostDTO postDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await postsService.UpdatePostAsync(id, postDTO);

            return Ok();
        }

        // POST: api/Posts
        [HttpPost]
        [ProducesResponseType(typeof(Post), 201)]
        public async Task<ActionResult<Post>> PostPost([FromBody]CreatePostDTO postDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = await postsService.CreatePostAsync(postDTO);

            return CreatedAtAction("GetPost", new { id = post.ID }, post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            await postsService.RemovePostAsync(id);
            
            return NoContent();
        }
    }
}
