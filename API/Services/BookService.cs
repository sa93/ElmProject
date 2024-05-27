using Dto;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class BookService : BaseService, IBookService
    {
        public BookService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<List<BookDto>> SearchBooksAsync(string keyword, int page, int pageSize)
        {
            //I am trying to deserialize bookInfo and apply the search functionality
            //var test = Db.Books.Where(x => x.BookInfo.Author == "s").Take(2).ToList();
            
            var query = Db.Books
              .Where(x => x.BookInfo != null && 
               (
               EF.Functions.Like(Db.JsonValue((string)(object)x.BookInfo, $"$.{nameof(BookInfoDto.BookTitle)}"), $"%{keyword}%") ||
               EF.Functions.Like(Db.JsonValue((string)(object)x.BookInfo, $"$.{nameof(BookInfoDto.BookDescription)}"), $"%{keyword}%") ||
               EF.Functions.Like(Db.JsonValue((string)(object)x.BookInfo, $"$.{nameof(BookInfoDto.Author)}"), $"%{keyword}%") ||
               EF.Functions.Like(Db.JsonValue((string)(object)x.BookInfo, $"$.{nameof(BookInfoDto.PublishDate)}"), $"%{keyword}%") ||
               EF.Functions.Like(Db.JsonValue((string)(object)x.BookInfo, $"$.{nameof(BookInfoDto.CoverBase64)}"), $"%{keyword}%")
               ))
              .Select(b => new BookDto
              {
                  Id = b.BookId,
                  LastModified = b.LastModified,
                  Title = b.BookInfo.BookTitle,
                  Description = b.BookInfo.BookDescription,
                  Author = b.BookInfo.Author,
                  PublishDate = b.BookInfo.PublishDate,
                  ImageUrl = b.BookInfo.CoverBase64
              }).Skip((page - 1) * pageSize)
                .Take(pageSize);
            // add pagesize to setting
            var queryString = query.ToQueryString();
            var booksDto = await query.ToListAsync();
            return booksDto;
        }
    }
}
