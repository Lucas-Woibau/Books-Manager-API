using GerenciamentoBiblioteca.Core.Entities;

namespace GerenciamentoBiblioteca.Application.Models
{
    public class CreateBookInputModel
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public int PublicationYear { get; set; }

        public Book ToEntity() 
            => new(Title, Author, ISBN, PublicationYear);
    }
}
