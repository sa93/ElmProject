using API.Services;
using Dto;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("Book")]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        private readonly ILogger<BookController> _logger;

        public BookController(BookService bookService, ILogger<BookController> logger)
        {
            _bookService = bookService; 
            _logger = logger;
        }

        [HttpGet(Name = "SearchBook")]
        public async Task<List<BookDto>> SearchBookAsync(string keyword, int page, int pageSize)
        {
            return await _bookService.SearchBooksAsync(keyword, page, pageSize);
        }
    }
}