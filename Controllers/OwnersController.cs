using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetPackApi.Data;
using PetPackApi.Models;

namespace PetPackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OwnersController(AppDbContext context)
        {
            _context = context;
        }

        // Criar Owner com Pack e Pets
        [HttpPost]
        public async Task<IActionResult> CreateOwner(Owner owner)
        {
            if (owner.Pack != null)
            {
                owner.Pack.Owner = owner;
                if (owner.Pack.Pets != null)
                {
                    foreach (var pet in owner.Pack.Pets)
                        pet.Pack = owner.Pack;
                }
            }

            _context.Owners.Add(owner);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOwner), new { id = owner.Id }, owner);
        }

        // Buscar Owner completo
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOwner(int id)
        {
            var owner = await _context.Owners
                .Include(o => o.Pack)
                .ThenInclude(p => p.Pets)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (owner == null)
                return NotFound();

            return Ok(owner);
        }
    }
}