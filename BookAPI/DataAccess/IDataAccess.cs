using BookAPI.Data.Entities;

namespace BookAPI.DataAccess
{
    public interface IDataAccess
    {
        List<Book> GetAllBooks();

        public  Task<Book> AddBook(string ISBN, string Title, string Description, string Author, string Genre);

        public Task<Book> UpdateBook(int Id, Book book);

        public Task<Book> DeleteBook(int Id);
    }
}