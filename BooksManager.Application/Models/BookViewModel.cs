using GerenciamentoBiblioteca.Core.Entities;
using GerenciamentoBiblioteca.Core.Enums;
using System.Text.Json.Serialization;

namespace GerenciamentoBiblioteca.Application.Models
{
    public class BookViewModel
    {
        public BookViewModel(string title, string author, string iSBN, int publicationYear, BookStatus status)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublicationYear = publicationYear;
            Status = status;
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }
        public int PublicationYear { get; private set; }

        [JsonIgnore]
        public BookStatus Status { get; private set; }

        public string StatusText => Status.ToString();

        public static BookViewModel FromEntity(Book entity) =>
            new(entity.Title, entity.Author, entity.ISBN, entity.PublicationYear, entity.Status);
    }
}
