using BookAPI.Data.Entities;
using BookAPI.Domain.Queries.GetAllBooks;
using MediatR;

namespace BookAPI.Domain.Queries.GetBookById
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IMediator _mediator;

        public GetBookByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var results = await _mediator.Send(new GetAllBooksQuery());

            var output = results.FirstOrDefault(x => x.Id == request.Id);

            return output;
        }
    }
}
