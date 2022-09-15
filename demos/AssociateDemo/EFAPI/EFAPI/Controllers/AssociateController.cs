using EFAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFAPI.Controllers
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
        [Authorize]
        public async Task<ActionResult<List<Associate>>> GetAll()
        {
            return Ok(await _context.Associates.ToListAsync());
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

            return Ok(await _context.Associates.ToListAsync());
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

            return Ok(await _context.Associates.ToListAsync());
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<List<Associate>>> DeleteAssociate(int id)
        {
            var associate = await _context.Associates.FindAsync(id);

            if (associate == null)
                return BadRequest("Associate not found.");

            _context.Associates.Remove(associate);
            await _context.SaveChangesAsync();

            return Ok(await _context.Associates.ToListAsync());
        }
    }
}
