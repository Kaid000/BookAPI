using BookAPI.Data.Entities;
using BookAPI.DataAccess;
using MediatR;

namespace BookAPI.Domain.Commands.RemoveBook
{
    public class RemoveBookCommandHandler : IRequestHandler<RemoveBookCommand, Book>
    {
        private readonly IDataAccess _data;

        public RemoveBookCommandHandler(IDataAccess data)
        {
            _data = data;
        }

        public Task<Book> Handle(RemoveBookCommand request, CancellationToken cancellationToken)
        {
            return _data.DeleteBook(request.Id);
        }
    }
}
