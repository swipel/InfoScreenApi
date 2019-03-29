using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using InfoScreenApi.Models;
using InfoScreenApi.ModelsDal;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;

namespace InfoScreenApi.Manager
{
    public class PostManager
    {
        public List<PostDTO> GetAllPost()
        {
            using (var context = new InfoScreenSchoolContext())
            {
                List<PostDTO> posts = (from p in context.Post
                    join pt in context.PostType on p.PostTypeId equals pt.PostTypeId
                    where p.Active == true && p.PostType.Name == "Text"
                    select new PostDTO()
                    {
                        PostType = new PostTypeDTO(pt.Name, pt.Created),
                        PostId = p.PostId,
                        Headline = p.Headline,
                        Text = p.Text,
                        Featured = p.Featured,
                        Created = p.Created,
                    }).ToList();

                //TODO Der må være en bedre måde end det her
                List<PostDTO> postsPicture = (from p in context.Post
                    join pt in context.PostType on p.PostTypeId equals pt.PostTypeId
                    where p.Active == true && p.PostType.Name == "Picture"
                    select new PostDTO()
                    {
                        PostType = new PostTypeDTO(pt.Name, pt.Created),
                        PostId = p.PostId,
                        Headline = p.Headline,
                        Text = p.Text,
                        Featured = p.Featured,
                        Created = p.Created,
                        Picture = Convert.ToBase64String(p.Image)
                    }).ToList();
                    
                var allPosts = posts.Concat(postsPicture).ToList().OrderByDescending(c => c.Created).ToList();            
                
                return allPosts;
            }
        }

        public int CreatePost(PostDTO postDto)
        {
            using (var context = new InfoScreenSchoolContext())
            {
                var postType = context.PostType.Where(a => a.Name == postDto.PostType.Name);
                Post post = new Post();
                post.Headline = postDto.Headline;
                post.Featured = postDto.Featured;
                post.Created = postDto.Created;
                post.PostType = postType.FirstOrDefault();
                if (post.PostType.PostTypeId.Equals(2))
                {
                    byte[] picture = Convert.FromBase64String(postDto.Picture);
                    post.Image = picture;
                }
                else
                {
                    post.Text = postDto.Text;                    
                }
                
                context.Add(post);
                return context.SaveChanges();
            }
        }

        public int UpdatePost(PostDTO postDto)
        {
            using (var context = new InfoScreenSchoolContext())
            {
                var post = context.Post.Single(a => a.PostId == postDto.PostId);
                post.Featured = postDto.Featured;
                if(post.Headline != null)
                post.Headline = postDto.Headline;
                if (postDto.PostType.Name.Equals("Text"))
                {
                    if (postDto.Text != null)
                        post.Text = postDto.Text;
                }
                else
                {
                    if (postDto.Picture != null)
                    {
                        byte[] picture = Convert.FromBase64String(postDto.Picture);
                        post.Image = picture;
                    }
                }

                context.Entry(post).State = EntityState.Modified;
                return context.SaveChanges();
            }
        }
        
        public int DeletePost(PostDTO postDto)
        {
            using (var context = new InfoScreenSchoolContext())
            {
                var post = context.Post.Single(a => a.PostId == postDto.PostId);
                post.Active = false;
                context.Entry(post).State = EntityState.Modified;
                return context.SaveChanges();
            }
        }
    }
}