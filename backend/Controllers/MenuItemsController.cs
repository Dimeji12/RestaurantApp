using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResturantApp.Models;

namespace ResturantApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class MenuItemsController : ControllerBase
    {
        private readonly ResturantAppContext _context;

        private readonly ILogger _logger;

        public MenuItemsController(ResturantAppContext context, ILogger<MenuItemsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/MenuItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetMenuItems()
        {
            _logger.LogInformation("Getting all menuitems");
            return await _context.MenuItems.ToListAsync();
        }

        // GET: api/MenuItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItem>> GetMenuItem(int id)
        {
            _logger.LogInformation("Getting menuitem by id");
            var menuItem = await _context.MenuItems.FindAsync(id);

            if (menuItem == null)
            {
                return NotFound();
            }

            return menuItem;
        }

        // PUT: api/MenuItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
       // [Authorize(Roles = "Admin")]

        public async Task<IActionResult> PutMenuItem(int id, MenuItem menuItem)
        {
            _logger.LogInformation("updating menuitem by id");
            if (id != menuItem.MenuItemId)
            {
                return BadRequest();
            }

            _context.Entry(menuItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItemExists(id))
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

        // POST: api/MenuItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
       // [Authorize(Roles = "Admin")]

        public async Task<ActionResult<MenuItem>> PostMenuItem(MenuItem menuItem)
        {
            _logger.LogInformation("Creating menuitems");
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenuItem", new { id = menuItem.MenuItemId }, menuItem);
        }

        // DELETE: api/MenuItems/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            _logger.LogInformation("Deleting menuitem by id");
            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuItemExists(int id)
        {
            return _context.MenuItems.Any(e => e.MenuItemId == id);
        }
    }
}
