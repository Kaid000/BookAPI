using BookAPI.Data;
using BookAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly ApplicationContext _db;
        
        public DataAccess(ApplicationContext db)
        {
            _db = db;
        }

        public List<Book> GetAllBooks()
        {
            return _db.Books.ToList();
        }

        public async Task<Book> AddBook(string ISBN, string Title, string Description, string Author, string Genre)
        { 
            Book book = new() { ISBN = ISBN, Author = Author, Title = Title, Description = Description, Genre = Genre};
            _db.Books.Add(book);
            await _db.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateBook(int Id, Book book)
        {
            Book newbook = await _db.Books.FirstOrDefaultAsync(x => x.Id == Id);
            _db.Books.Remove(newbook);
            newbook = book;
            newbook.Id = Id;
            await _db.Books.AddAsync(newbook);
            await _db.SaveChangesAsync();
            return await Task.FromResult(newbook);
        }

        public async Task<Book> DeleteBook(int Id)
        {
            var book = await _db.Books.FirstOrDefaultAsync(x => x.Id == Id);
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
            return book;
        }
    }
}