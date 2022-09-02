using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IoT_Project.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading;

namespace IoT_Project.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly sqldbconnectedofficeContext _context;

        public CategoriesController(sqldbconnectedofficeContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            return await _context.Category.ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(Guid id)
        {
            var category = await _context.Category.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // Method retrieves all devices that is part of a certain category
        //GET: api/Categories/5/Devices
        [HttpGet("{id}/Devices")]
        public async Task<ActionResult<Category>> GetCategoryDevices(Guid id)
        {
            if (!CategoryExists(id))
            {
                return NotFound();
            }

            var query = await _context.Category.Join(_context.Device, category => category.CategoryId, device => device.CategoryId, (category, device) => new
            {
                Category = category,
                Device = device,
            }).Where(entity => entity.Device.CategoryId == id).Select(entity => entity.Device).ToListAsync();

            return Ok(query);
        }

        // GET method to retrieve number of zones associated to a specific category
        // GET: api/Gategories/5/zones
        [HttpGet("{id}/Zones")]
        public async Task<ActionResult<Category>> GetCategoryZones(Guid id)
        {
            if (!CategoryExists(id))
            {
                return NotFound();
            }

            var query = await _context.Category.Join(_context.Device, category => category.CategoryId, device => device.CategoryId, (category, device) => new
            {
                Category = category,
                Device =device,
            }).Join(_context.Zone, device => device.Device.ZoneId, zone => zone.ZoneId, (zone, device) => new
            {
                Zone = zone,
                Device = device
            }).Where(e => e.Zone.Device.CategoryId == id).Select(e => e.Device.ZoneId).ToListAsync();
            return Ok(query.Count());
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(Guid id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _context.Category.Add(category);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategoryExists(category.CategoryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(Guid id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }

        private bool CategoryExists(Guid id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }
    }
}
