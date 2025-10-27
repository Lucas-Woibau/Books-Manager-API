using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Enums;

namespace GerenciamentoBiblioteca.Application.Models
{
    public class BookViewModel
    {
        public BookViewModel(int id, string title, string author, string iSBN, int publicationYear, BookStatus status)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublicationYear = publicationYear;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int PublicationYear { get; private set; }
        public BookStatus Status { get; private set; }

        public static BookViewModel FromEntity(Book entity) =>
            new(entity.Id, entity.Title, entity.Author, entity.ISBN, entity.PublicationYear, entity.Status);
    }
}
