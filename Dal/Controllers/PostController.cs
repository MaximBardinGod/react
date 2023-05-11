
using Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dal.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        ApplicationContext _context;
        public PostController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _context.Post.ToListAsync();
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Post.FindAsync(id);
            if (mentor == null) return NotFound();
            return await mentor.WithClients(_context);
        }

        [HttpPost("PostMentor")] //api/client/updateMentor
        public async Task<ActionResult<Mentor>> PostMentor(Mentor mentor)
        {
            if (mentor == null) return BadRequest();
            _context.Mentor.Add(mentor);
            await _context.SaveChangesAsync();
            return Ok(mentor);
        }

        [HttpPut("PutMentor")]
        public async Task<ActionResult<Mentor>> Put(Mentor mentor)
        {
            if (mentor == null) return BadRequest();

            _context.Update(mentor);
            await _context.SaveChangesAsync();
            return Ok(mentor);
        }

        [HttpDelete("DeleteMentor/{Id}")]
        public async Task<ActionResult<Mentor>> Delete(int id)
        {
            var mentor = _context.Mentor.FirstOrDefaultAsync(p => p.MentorId == id);
            if (mentor == null) return NotFound();
            _context.Mentor.Remove(await mentor);
            await _context.SaveChangesAsync();
            return Ok(mentor);
        }
    }
}
