using Books.BackendServer.Data;
using Books.BackendServer.Data.Entities;
using Books.ViewModels;
using Books.ViewModels.Systems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Books.BackendServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> PostBook([FromBody] BookCreateRequest request)
        {
            var book = new Book()
            {
                Title = request.Title,
                Topic = request.Topic,
                AuthorId = request.AuthorId,
                PublishYear = request.PublishYear,
                Price = request.Price,
                Rating = request.Rating
            };
            _context.Books.Add(book);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return CreatedAtAction(nameof(GetById), new { id = book.Id }, request);
            }
            else
            {
                return BadRequest();
            }
        }


        //URL: GET https://localhost:7200/api/Books
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = _context.Books;

            var book = await books.Select(u => new BookVm()
            {
                Id = u.Id,
                Title = u.Title,
                Topic = u.Topic,
                AuthorId = u.AuthorId,
                PublishYear = u.PublishYear,
                Price = u.Price,
                Rating = u.Rating,
            }).ToListAsync();

            return Ok(book);
        }

        //URL https://localhost:7200/api/Books/filter?filter={filter}&pageIndex=1&pageSize=1
        //topic
        [HttpGet("filter")]
        public async Task<IActionResult> GetBookPaging(string filter, int pageIndex, int pageSize)
        {
            var query = _context.Books.AsQueryable();
            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(x => x.Topic.Contains(filter));
            }
            var totalRecords = await query.CountAsync();
            var items = await query.Skip((pageIndex - 1 * pageSize))
                .Take(pageSize)
                .Select(u => new BookVm()
                {
                    Id = u.Id,
                    AuthorId =u.AuthorId,
                    Rating = u.Rating,
                    PublishYear=u.PublishYear,
                    Price = u.Price,
                    Topic = u.Topic,
                    Title = u.Title
                })
                .ToListAsync();

            var pagination = new Pagination<BookVm>
            {
                Items = items,
                TotalRecords = totalRecords,
            };
            return Ok(pagination);
        }


        //URL: GET: https://localhost:7200/api/Books/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            var bookVm = new BookVm()
            {
                Id = book.Id,
                AuthorId = book.AuthorId,
                Title = book.Title,
                Topic = book.Topic,
                PublishYear = book.PublishYear,
                Price = book.Price,
                Rating = book.Rating

            };
            return Ok(bookVm);
        }




        //URL : PUT https://localhost:7200/api/Books/{id}
        [HttpPut ("{id}")]
        public async Task<IActionResult> PutBook(int id, [FromBody] BookCreateRequest request)
        {
            var book = await _context.Books.FindAsync (id);
            if (book == null)
                return NotFound();
            
            book.Title = request.Title;
            book.Topic = request.Topic;
            book.AuthorId = request.AuthorId;
            book.PublishYear = request.PublishYear;
            book.Price = request.Price;
            book.Rating = request.Rating;

            _context.Books.Update(book);
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return NoContent();
            }
            return BadRequest();
        }

        // URL :DELETE https://localhost:7200/api/Books/{id}
        [HttpDelete ("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            _context.Books.Remove(book);
            var result = await _context.SaveChangesAsync();
            

            if (result > 0)
            {
                var bookVm = new BookVm()
                {
                    Id = book.Id,
                    AuthorId = book.AuthorId,
                    Title = book.Title,
                    Topic = book.Topic,
                    PublishYear = book.PublishYear,
                    Price = book.Price,
                    Rating = book.Rating

                };
                return Ok(bookVm);
            }
            else
            {
                return BadRequest();
            }
        }

    }

}
