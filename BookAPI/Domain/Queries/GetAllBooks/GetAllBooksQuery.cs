using BookAPI.Data.Entities;
using MediatR;

namespace BookAPI.Domain.Queries.GetAllBooks
{
    public record GetAllBooksQuery() : IRequest<List<Book>>;
}
