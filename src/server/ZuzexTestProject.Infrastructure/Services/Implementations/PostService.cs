﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuzexTestProject.Domain.Model;
using ZuzexTestProject.Infrastructure.DTO;
using ZuzexTestProject.Infrastructure.EF;
using ZuzexTestProject.Infrastructure.Exceptions;

namespace ZuzexTestProject.Infrastructure.Services
{
    public class PostService : IPostsService
    {
        private readonly PostsContext context;
        private readonly IMapper mapper;

        public PostService(PostsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Post> CreatePostAsync(CreatePostDTO postDTO)
        {
            var post = mapper.Map<Post>(postDTO);
            post.DatePosted = DateTime.Now;

            context.Posts.Add(post);
            await context.SaveChangesAsync();

            return post;
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            var posts = await context.Posts
                                     .Select(p => new Post
                                     {
                                         ID = p.ID,
                                         Title = p.Title,
                                         Annotation = p.Annotation,
                                         DatePosted = p.DatePosted,
                                         DateRefreshed = p.DateRefreshed
                                     }).ToListAsync();

            return posts;
        }

        public async Task<Post> GetPostDetailAsync(int id)
        {
            var post = await context.Posts.FindAsync(id);
            if (post == null)
            {
                throw new NotFoundException(ErrorCode.ResourceNotFound, "post was not found");
            }

            return post;
        }

        public async Task RemovePostAsync(int id)
        {
            var post = await context.Posts.FindAsync(id);

            if (post == null)
            {
                throw new NotFoundException(ErrorCode.ResourceNotFound, "post was not found");
            }

            context.Remove(post);
            await context.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(int id, CreatePostDTO postDTO)
        {
            var post = await context.Posts.FindAsync(id);

            if (post == null)
            {
                post = mapper.Map<Post>(postDTO);
                post.DatePosted = DateTime.Now;

                context.Posts.Add(post);

                await context.SaveChangesAsync();
            }
            else
            {
                post.Annotation = postDTO.Annotation;
                post.Content = postDTO.Content;
                post.Title = postDTO.Title;
                post.DateRefreshed = DateTime.Now;

                context.Entry(post).State = EntityState.Modified;

                await context.SaveChangesAsync();
            }
        }
    }
}