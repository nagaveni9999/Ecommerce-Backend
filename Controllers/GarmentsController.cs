using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineShopping11.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Onlineshopping11.Models.ProductDBContext;

namespace Onlineshopping11.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GarmentsController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public int GarmentId { get; private set; }

        public GarmentsController(ProductDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Garments>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Garments>> GetGarment(int id)
        {
            var Garment = await _context.Products.FindAsync(id);

            if (Garment == null)
            {
                return NotFound();
            }

            return Garment;
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGarments(int id, Garments garments)
        {
            if (id != GarmentId)
            {
                return BadRequest();
            }

            _context.Entry(garments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GarmentExists(id))
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


        [HttpPost]
        public async Task<ActionResult<Garments>> PostGarment(Garments garment)
        {
           
                _context.Add(garment);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetGarment", new { id = garment.Id }, garment);
            
            
        }




        [HttpDelete("{id}")]
        public async Task<ActionResult<Garments>> DeleteGarments(int id, ProductDbContext _context)
        {
            var garments = await _context.Products.FindAsync(id);
            if (garments == null)
            {
                return NotFound();
            }

            _context.Products.Remove(garments);
            await _context.SaveChangesAsync();

            return garments;
        }

        private bool GarmentExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}



