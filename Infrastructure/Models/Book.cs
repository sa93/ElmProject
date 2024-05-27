using Dto;

namespace Infrastructure.Models
{
    public partial class Book
    {
        public long BookId { get; set; }
        public BookInfoDto BookInfo { get; set; } = null!;
        public DateTime LastModified { get; set; }
    }
}
