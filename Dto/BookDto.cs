namespace Dto
{
    public class BookDto
    {
        public long Id { get; set; }
        public DateTime LastModified { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string PublishDate { get; set; }
        public string ImageUrl { get; set; }
    }
}