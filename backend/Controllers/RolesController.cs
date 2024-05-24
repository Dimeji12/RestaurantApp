using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ResturantApp.Models;

namespace ResturantApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize(Roles = "Admin")]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger _logger;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, ILogger < RolesController>logger)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            _logger.LogInformation("Getting all Roles ");
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }

        [HttpGet("{roleId}")]
        public async Task<IActionResult> GetRole(string roleId)
        {
            _logger.LogInformation("Getting Role by id");
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                return NotFound("Role not found.");
            }

            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            _logger.LogInformation("Creating Role");
            var role = new IdentityRole(roleName);
            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return Ok("Role created successfully.");
            }

            return BadRequest(result.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleModel model)
        {
            _logger.LogInformation("Updating Role");
            var role = await _roleManager.FindByIdAsync(model.RoleId);

            if (role == null)
            {
                return NotFound("Role not found.");
            }

            role.Name = model.NewRoleName;
            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return Ok("Role updated successfully.");
            }

            return BadRequest(result.Errors);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            _logger.LogInformation("Deleting Role");
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                return NotFound("Role not found.");
            }

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                return Ok("Role deleted successfully.");
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("assign-role-to-user")]
        public async Task<IActionResult> AssignRoleToUser([FromBody] AssignRoleModel model)
        {
            _logger.LogInformation("Assigning Role");
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            var roleExists = await _roleManager.RoleExistsAsync(model.RoleName);

            if (!roleExists)
            {
                return NotFound("Role not found.");
            }

            var result = await _userManager.AddToRoleAsync(user, model.RoleName);

            if (result.Succeeded)
            {
                return Ok("Role assigned to user successfully.");
            }

            return BadRequest(result.Errors);
        }

    }
}

