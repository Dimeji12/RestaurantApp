using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResturantApp.Models;

namespace ResturantApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class StaffsController : ControllerBase
    {
        private readonly ResturantAppContext _context;
        private readonly ILogger _logger;
        public StaffsController(ResturantAppContext context, ILogger <StaffsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Staffs
        [HttpGet]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<IEnumerable<Staff>>> GetStaffs()
        {
            _logger.LogInformation("Get Staffs");
            return await _context.Staffs.ToListAsync();
        }

        // GET: api/Staffs/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
            _logger.LogInformation("Get Staff by Id ");
            var staff = await _context.Staffs.FindAsync(id);

            if (staff == null)
            {
                return NotFound();
            }

            return staff;
        }

        // PUT: api/Staffs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> PutStaff(int id, Staff staff)
        {
            _logger.LogInformation("Updating Staff");
            if (id != staff.StaffId)
            {
                return BadRequest();
            }

            _context.Entry(staff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
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

        // POST: api/Staffs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        

        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
            _logger.LogInformation("Creating Staffs");
            _context.Staffs.Add(staff);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaff", new { id = staff.StaffId }, staff);
        }

        // DELETE: api/Staffs/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteStaff(int id)
        {
            _logger.LogInformation("Deleting Staff by id");
            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StaffExists(int id)
        {
            return _context.Staffs.Any(e => e.StaffId == id);
        }
    }
}
