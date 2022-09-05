using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IoT_Project.Models;
using Microsoft.AspNetCore.Authorization;

namespace IoT_Project.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ZonesController : ControllerBase
    {
        private readonly sqldbconnectedofficeContext _context;

        public ZonesController(sqldbconnectedofficeContext context)
        {
            _context = context;
        }

        // Get method to retrieve all zones
        // GET: api/Zones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zone>>> GetZone()
        {
            return await _context.Zone.ToListAsync();
        }

        // Get method to retrieve a specific zone
        // GET: api/Zones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zone>> GetZone(Guid id)
        {
            var zone = await _context.Zone.FindAsync(id);

            if (zone == null)
            {
                return NotFound();
            }

            return zone;
        }

        // Get method to retrieve all devices that are part of a certain zone
        //GET: api/Zones/5/Devices
        [HttpGet("{id}/Devices")]
        public async Task<ActionResult<Zone>> GetZoneDevices(Guid id)
        {
            if (!ZoneExists(id))
            {
                return NotFound();
            }

            var query = await _context.Zone.Join(_context.Device, zone => zone.ZoneId, device => device.ZoneId, (zone, device) => new
            {
                Zone = zone,
                Device = device,
            }).Where(entity => entity.Device.ZoneId == id).Select(entity => entity.Device).ToListAsync();
            return Ok(query);
        }

        // Put/Patch method to update a zone
        // PUT: api/Zones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZone(Guid id, Zone zone)
        {
            if (id != zone.ZoneId)
            {
                return BadRequest();
            }

            _context.Entry(zone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZoneExists(id))
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

        // Post method to insert a new zone
        // POST: api/Zones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Zone>> PostZone(Zone zone)
        {
            _context.Zone.Add(zone);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ZoneExists(zone.ZoneId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetZone", new { id = zone.ZoneId }, zone);
        }

        // Delete method to delete a zone
        // DELETE: api/Zones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Zone>> DeleteZone(Guid id)
        {
            var zone = await _context.Zone.FindAsync(id);
            if (zone == null)
            {
                return NotFound();
            }

            _context.Zone.Remove(zone);
            await _context.SaveChangesAsync();

            return zone;
        }

        // Method to check if zone exists
        private bool ZoneExists(Guid id)
        {
            return _context.Zone.Any(e => e.ZoneId == id);
        }
    }
}
