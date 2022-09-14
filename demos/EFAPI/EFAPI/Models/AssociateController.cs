using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace EFAPI.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssociateController : ControllerBase
    {
        BatchContext _context;

        public AssociateController(BatchContext batchContext)
        {
            _context = batchContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Associate>>> GetAll()
        {
            return Ok( _context.Associates.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Associate>> GetOne(int id)
        {
            var associate = await _context.Associates.FindAsync(id);
            if (associate == null)
                return BadRequest("Associate not found.");
            return Ok(associate);
        }

        [HttpPost]
        public async Task<ActionResult<List<Associate>>> AddAssociate(Associate newAssociate)
        {
            _context.Associates.Add(newAssociate);
            await _context.SaveChangesAsync();

            return Ok(_context.Associates.ToList());
        }

        [HttpPut]
        public async Task<ActionResult<List<Associate>>> UpdateAssociate(Associate update)
        {
            var associate = await _context.Associates.FindAsync(update.Id);

            if (associate == null)
                return BadRequest("Associate not found.");

            associate.FirstMidName = update.FirstMidName;
            associate.LastName = update.LastName;
            associate.DOB = update.DOB;

            await _context.SaveChangesAsync();

            return Ok( _context.Associates.ToList());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Associate>>> DeleteAssociate(int id)
        {
            var associate = await _context.Associates.FindAsync(id);

            if (associate == null)
                return BadRequest("Associate not found.");

            _context.Associates.Remove(associate);
            await _context.SaveChangesAsync();

            return Ok(_context.Associates.ToList());
        }
    }
}
