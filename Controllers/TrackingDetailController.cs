using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vehicle_System_API.Models;

namespace Vehicle_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingDetailController : ControllerBase
    {
        private readonly VehicleTrackingContext _context;

        public TrackingDetailController(VehicleTrackingContext context)
        {
            _context = context;
        }

        // GET: api/TrackingDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrackingDetail>>> GetTrackingDetails()
        {
            return await _context.TrackingDetails.Include(t => t.VIdNavigation).ToListAsync();
        }

        // GET: api/TrackingDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrackingDetail>> GetTrackingDetail(int id)
        {
            var trackingDetail = await _context.TrackingDetails.FindAsync(id);

            if (trackingDetail == null)
            {
                return NotFound();
            }

            return trackingDetail;
        }

        // PUT: api/TrackingDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrackingDetail(int id, TrackingDetail trackingDetail)
        {
            if (id != trackingDetail.TrackingId)
            {
                return BadRequest();
            }

            _context.Entry(trackingDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackingDetailExists(id))
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

        // POST: api/TrackingDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrackingDetail>> PostTrackingDetail(TrackingDetail trackingDetail)
        {
            _context.TrackingDetails.Add(trackingDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrackingDetail", new { id = trackingDetail.TrackingId }, trackingDetail);
        }

        // DELETE: api/TrackingDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrackingDetail(int id)
        {
            var trackingDetail = await _context.TrackingDetails.FindAsync(id);
            if (trackingDetail == null)
            {
                return NotFound();
            }

            _context.TrackingDetails.Remove(trackingDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrackingDetailExists(int id)
        {
            return _context.TrackingDetails.Any(e => e.TrackingId == id);
        }
    }
}
