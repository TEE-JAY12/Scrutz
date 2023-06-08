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
    public class TweetMetricsController : ControllerBase
    {
        private readonly ScrutzContext _context;

        public TweetMetricsController(ScrutzContext context)
        {
            _context = context;
        }

        // GET: api/TweetMetrics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TweetMetric>>> GetTweetMetrics()
        {
          if (_context.TweetMetrics == null)
          {
              return NotFound();
          }
            return await _context.TweetMetrics.ToListAsync();
        }

        // GET: api/TweetMetrics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TweetMetric>> GetTweetMetric(string id)
        {
          if (_context.TweetMetrics == null)
          {
              return NotFound();
          }
            var tweetMetric = await _context.TweetMetrics.FindAsync(id);

            if (tweetMetric == null)
            {
                return NotFound();
            }

            return tweetMetric;
        }

        // PUT: api/TweetMetrics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTweetMetric(string id, TweetMetric tweetMetric)
        {
            if (id != tweetMetric.TweetID)
            {
                return BadRequest();
            }

            _context.Entry(tweetMetric).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TweetMetricExists(id))
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

        // POST: api/TweetMetrics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TweetMetric>> PostTweetMetric(TweetMetric tweetMetric)
        {
          if (_context.TweetMetrics == null)
          {
              return Problem("Entity set 'ScrutzContext.TweetMetrics'  is null.");
          }
            _context.TweetMetrics.Add(tweetMetric);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TweetMetricExists(tweetMetric.TweetID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTweetMetric", new { id = tweetMetric.TweetID }, tweetMetric);
        }

        // DELETE: api/TweetMetrics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTweetMetric(string id)
        {
            if (_context.TweetMetrics == null)
            {
                return NotFound();
            }
            var tweetMetric = await _context.TweetMetrics.FindAsync(id);
            if (tweetMetric == null)
            {
                return NotFound();
            }

            _context.TweetMetrics.Remove(tweetMetric);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TweetMetricExists(string id)
        {
            return (_context.TweetMetrics?.Any(e => e.TweetID == id)).GetValueOrDefault();
        }
    }
}
