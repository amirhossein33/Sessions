namespace ContextPoolingWithState.Controllers
{
  
    // Controllers/LibraryController.cs
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    namespace LibraryMultiTenancy.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class LibraryController : ControllerBase
        {
            private readonly LibraryContext _dbContext;

            public LibraryController(LibraryContext dbContext)
                => _dbContext = dbContext;

            [HttpGet(Name = "GetBooks")]
            public async Task<IEnumerable<Book>> Get()
                => await _dbContext.Books.OrderBy(b => b.PublishedDate).Take(5).ToArrayAsync();

            [HttpPost]
            public async Task<IActionResult> AddBook([FromBody] Book newBook)
            {
                _dbContext.Books.Add(newBook);
                await _dbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
            }
        }
    }

}
