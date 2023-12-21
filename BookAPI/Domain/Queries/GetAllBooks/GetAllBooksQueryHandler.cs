using BookAPI.Data.Entities;
using BookAPI.DataAccess;
using MediatR;

namespace BookAPI.Domain.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<Book>>
    {
        private readonly IDataAccess _data;

        public GetAllBooksQueryHandler(IDataAccess data)
        {
            _data = data;
        }

        public Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_data.GetAllBooks());
        }
    }
}
