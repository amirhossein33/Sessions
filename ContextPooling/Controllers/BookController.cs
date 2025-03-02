using Microsoft.AspNetCore.Mvc;

namespace ContextPooling.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookLibraryContext _dbContext;

        public BookController(BookLibraryContext dbContext)
            => _dbContext = dbContext;

        [HttpGet(Name = "GetBooks")]
        public async Task<IEnumerable<Book>> Get()
            => await _dbContext.Books.OrderBy(b => b.PublishedDate).Take(5).ToArrayAsync();
    }

}
