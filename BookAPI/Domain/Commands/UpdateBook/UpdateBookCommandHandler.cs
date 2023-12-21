using BookAPI.Data.Entities;
using BookAPI.DataAccess;
using MediatR;

namespace BookAPI.Domain.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly IDataAccess _data;

        public UpdateBookCommandHandler(IDataAccess data)
        {
            _data = data;
        }

        public Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            return _data.UpdateBook(request.Id, request.book);
        }
    }
}
