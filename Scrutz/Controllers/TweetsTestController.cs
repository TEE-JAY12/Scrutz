using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scrutz.Data;
using Scrutz.Model;

namespace Scrutz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetsTestController : ControllerBase
    {
        private readonly ScrutzContext _context;

        public TweetsTestController(ScrutzContext context)
        {
            _context = context;
        }

        // GET: api/TweetsTest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tweets>>> GetTweet()
        {
          if (_context.Tweet == null)
          {
              return NotFound();
          }
            return await _context.Tweet.ToListAsync();
        }

        // GET: api/TweetsTest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tweets>> GetTweets(string id)
        {
          if (_context.Tweet == null)
          {
              return NotFound();
          }
            var tweets = await _context.Tweet.FindAsync(id);

            if (tweets == null)
            {
                return NotFound();
            }

            return tweets;
        }

        // PUT: api/TweetsTest/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTweets(string id, Tweets tweets)
        {
            if (id != tweets.TweetID)
            {
                return BadRequest();
            }

            _context.Entry(tweets).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TweetsExists(id))
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

        // POST: api/TweetsTest
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tweets>> PostTweets(Tweets tweets)
        {
          if (_context.Tweet == null)
          {
              return Problem("Entity set 'ScrutzContext.Tweet'  is null.");
          }
            _context.Tweet.Add(tweets);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TweetsExists(tweets.TweetID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTweets", new { id = tweets.TweetID }, tweets);
        }

        // DELETE: api/TweetsTest/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTweets(string id)
        {
            if (_context.Tweet == null)
            {
                return NotFound();
            }
            var tweets = await _context.Tweet.FindAsync(id);
            if (tweets == null)
            {
                return NotFound();
            }

            _context.Tweet.Remove(tweets);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TweetsExists(string id)
        {
            return (_context.Tweet?.Any(e => e.TweetID == id)).GetValueOrDefault();
        }
    }
}
