using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Perfumeria.Data;

namespace Perfumeria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PerfumeController : ControllerBase 
    {
        private readonly AppDbContext _context;

        public PerfumeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllPerfume()
        {
            List<ResponsePerfumeDto> perfumes = await _context.Perfumes.Select(
                perfume => new ResponsePerfumeDto {
                    Name = perfume.Name,
                    Brand = perfume.Brand,
                    Price = perfume.Price,
                    Stock = perfume.Stock,
                    Description = perfume.Description
                }
            ).ToListAsync();

            return Ok(perfumes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var perfume = await _context.Perfumes.FindAsync(id);

            if (perfume == null) return NotFound();

            return Ok(perfume);
        }

        [HttpGet("{brand}")]
        public async Task<IActionResult> GetByBrand(string brand)
        {
            var perfumesByBrand = await _context.Perfumes.Where(perfume => perfume.Brand == brand).ToListAsync();

            if (perfumesByBrand == null || perfumesByBrand.Count == 0) 
            return NotFound();

            return Ok(perfumesByBrand);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerfume(int id, [FromBody] ResponsePerfumeDto dto)
        {
            var perfume = await _context.Perfumes.FindAsync(id);
            if (perfume == null) return NotFound();

            perfume.Name = dto.Name;
            perfume.Brand = dto.Brand;
            perfume.Price = dto.Price;
            perfume.Stock = dto.Stock;
            perfume.Description = dto.Description;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var perfume = await _context.Perfumes.FindAsync(id);
            if (perfume == null) return NotFound();

            _context.Perfumes.Remove(perfume);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }


}