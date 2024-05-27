using Dto;

namespace API.Services
{
    public interface IBookService
    {
        public Task<List<BookDto>> SearchBooksAsync(string keyword, int page, int pageSize);
    }
}