using Books.BackendServer.Data;
using Books.BackendServer.Data.Entities;
using Books.ViewModels.Systems;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Books.BackendServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //URL : GET https://localhost:7200/api/Authors
        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = _context.Authors;

            var book = await authors.Select(u => new AuthorVm()
            {
                Id = u.Id,
                Name = u.Name,
                Female = u.Female,
                Born = u.Born,
                Died = u.Died,
                
            }).ToListAsync();

            return Ok(book);
        }
    }
}
