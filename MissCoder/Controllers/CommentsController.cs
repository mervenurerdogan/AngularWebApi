using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MissCoder.Models;
using MissCoder.Responses;

namespace MissCoder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly UdemyAngularprojectDBContext _context;

        public CommentsController(UdemyAngularprojectDBContext context)
        {
            _context = context;
        }

        // GET: api/Comments
        [HttpGet]
        public IActionResult GetComments()
        {

            var comments = _context.Comments.Include(x => x.Article).OrderByDescending(z => z.PublishDate).ToList().Select(a => new CommentResponse()
            {
                Id = a.Id,
                Article = new ArticleResponse() { Id = a.Article.Id, Title = a.Article.Title, ContentSumary = a.Article.ContentSumary },
                Name = a.Name,
                ContentMain = a.ContentMain,
                PublishDate = a.PublishDate,



            });
            return Ok(comments);
        }

        // GET: api/Comments/5

        [HttpGet("{id}")]
        public IActionResult GetCommentList(int id)
        {
            var comments = _context.Comments.Where(a => a.ArticleId == id).OrderByDescending(z => z.PublishDate).ToList();

            if (comments == null)
            {
                return NotFound();
            }
            return Ok(comments);
        }


        // PUT: api/Comments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }

            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Comments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            System.Threading.Thread.Sleep(2500);
            comment.PublishDate = System.DateTime.Now;

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return Ok();
        }





        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comment>> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
