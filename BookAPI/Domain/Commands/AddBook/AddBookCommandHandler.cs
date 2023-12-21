using BookAPI.Data.Entities;
using BookAPI.DataAccess;
using MediatR;

namespace BookAPI.Domain.Commands.InsertBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Book>
    {
        private readonly IDataAccess _data;

        public AddBookCommandHandler(IDataAccess data)
        {
            _data = data;
        }

        public Task<Book> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            return _data.AddBook(request.ISBN, request.Title, request.Description, request.Author, request.Genre);
        }
    }
}
