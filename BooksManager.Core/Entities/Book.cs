using GerenciamentoBiblioteca.Core.Enums;

namespace GerenciamentoBiblioteca.Core.Entities
{
    public class Book : BaseEntity
    {
        public Book() { }
        public Book(string? title, string? author, string? isbn, int publicationYear)
            : base()
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            PublicationYear = publicationYear;

            SetAvailable();
        }

        public int Id { get; set; }
        public string? Title { get; private set; }
        public string? Author { get; private set; }
        public string? ISBN { get; private set; }
        public int PublicationYear { get; private set; }
        public BookStatus Status { get; private set; }

        public bool SetAvailable()
        {
            Status = BookStatus.Available;
            return true;
        }
        public bool SetUnavailable()
        {
            Status = BookStatus.Unavailable;
            return true;
        }

        public void Update(string title, string author, string isbn, int publicationYear)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            PublicationYear = publicationYear;
        }
    }
}
