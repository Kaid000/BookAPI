using BookAPI.Data.Entities;
using BookAPI.Domain.Queries.GetAllBooks;
using MediatR;

namespace BookAPI.Domain.Queries.GetBookByISBN
{
    public class GetBookByISBNQueryHandler : IRequestHandler<GetBookByISBNQuery, Book>
    {
        private readonly IMediator _mediator;
        public GetBookByISBNQueryHandler(IMediator mediator)
        {

            _mediator = mediator;

        }
        public async Task<Book> Handle(GetBookByISBNQuery request, CancellationToken cancellationToken)
        {
            var results = await _mediator.Send(new GetAllBooksQuery());

            var output = results.FirstOrDefault(x => x.ISBN == request.ISBN);

            return output;
        }
    }
}
