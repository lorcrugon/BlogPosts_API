using BlogPosts_API.Data;
using BlogPosts_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogPosts_API.Controllers
{
    public class BlogPostsController : ApiController
    {
        BlogPostsDbContext blogPostsDbContext = new BlogPostsDbContext();

        // GET: api/BlogPosts
        [HttpGet]
        public IHttpActionResult LoadBlogPosts()
        {
            var blogPosts = blogPostsDbContext.BlogPosts;
            return Ok(blogPosts);
        }


        [HttpGet]
        public IHttpActionResult LoadBlogPosts(string sort) //https://localhost:44300/api/blogPosts?sort=asc
        {
            IQueryable<BlogPost> blogPosts;
            switch (sort)
            {
                case "desc":
                    blogPosts = blogPostsDbContext.BlogPosts.OrderByDescending(q => q.Title);
                    break;
                case "asc":
                    blogPosts = blogPostsDbContext.BlogPosts.OrderBy(q => q.Title);
                    break;
                default:
                    blogPosts = blogPostsDbContext.BlogPosts;
                    break;

            }
            //var blogPosts = blogPostsDbContext.BlogPosts;
            return Ok(blogPosts);
        }

        [HttpGet]
        [Route("api/blogposts/Paging/{pageNumber=1}/{pageSize=5}")] //https://localhost:44300/api/blogPosts/Paging?pageNumber=1&pageSize=3
        public IHttpActionResult PagingBlogPosts(int pageNumber, int pageSize)
        {
            var blogPosts = blogPostsDbContext.BlogPosts.OrderBy(q => q.BlogPostId);
            return Ok(blogPosts.Skip((pageNumber - 1) * pageSize).Take(pageSize));
        }

        [HttpGet]
        [Route("api/blogposts/OffsetLimit/{offset=0}/{limit=2}")] //https://localhost:44300/api/blogPosts/OffsetLimit?offset=2&limit=2
        public IHttpActionResult OffsetLimitBlogPosts(int offset, int limit)
        {
            var blogPosts = blogPostsDbContext.BlogPosts.OrderBy(q => q.BlogPostId);
            return Ok(blogPosts.Skip(offset).Take(limit));
        }


        [HttpGet]
        [Route("api/blogposts/Search/{title=}")] //https://localhost:44300/api/blogPosts/Search?title=f
        public IHttpActionResult SearchBlogPosts(string title)
        {
            var blogPosts = blogPostsDbContext.BlogPosts.Where(q => q.Title.StartsWith(title));
            return Ok(blogPosts);
        }

        // GET: api/BlogPosts/5
        [HttpGet]
        public IHttpActionResult LoadBlogPosts(int id)
        {
            var blogPost = blogPostsDbContext.BlogPosts.Find(id);
            if(blogPost == null)
            {
                return NotFound();
            }
            return Ok(blogPost);
        }

        [HttpGet]
        [Route("api/blogposts/Test/{id}")]
        public int Test(int id)
        {
            return id;
        }

        // POST: api/BlogPosts
        [HttpPost]
        public IHttpActionResult Post([FromBody]BlogPost blogPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            blogPostsDbContext.BlogPosts.Add(blogPost);
            blogPostsDbContext.SaveChanges();
            return StatusCode(HttpStatusCode.Created);
        }

        // PUT: api/BlogPosts/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] BlogPost blogPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            
            var entity = blogPostsDbContext.BlogPosts.FirstOrDefault(q => q.BlogPostId == id);
            if (entity == null)
            {
                return BadRequest("No record found against this id");
            }
            entity.Title = blogPost.Title;
            entity.Body = blogPost.Body;
            entity.AuthorId = blogPost.AuthorId;
            //entity.CreatedAt = blogPost.CreatedAt;
            entity.UpdatedAt = blogPost.UpdatedAt;
            blogPostsDbContext.SaveChanges();
            return Ok("Record Updated successfully ...");

        }

        // DELETE: api/BlogPosts/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            //var blogPost = blogPostsDbContext.BlogPosts.Find(id);
            var entity = blogPostsDbContext.BlogPosts.FirstOrDefault(q => q.BlogPostId == id);
            if (entity == null)
            {
                return BadRequest("No record found against this id");
            }
            //blogPostsDbContext.BlogPosts.Remove(blogPost);
            blogPostsDbContext.BlogPosts.Remove(entity);
            blogPostsDbContext.SaveChanges();
            return Ok("BlogPost deleted.");
        }
    }
}
