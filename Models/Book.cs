namespace ThirdDotNet.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Author author { get; set; }
        
        public Book(int id, string title, string description, Author author)
        {
            Id = id;
            Title = title;
            Description = description;
            this.author = author;
        }

        public Book()
        {
            Id = 0;
            Title = "";
            Description = "";
            this.author = new Author();
        }
    }
}
