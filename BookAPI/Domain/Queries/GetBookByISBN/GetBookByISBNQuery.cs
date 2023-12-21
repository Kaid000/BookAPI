using BookAPI.Data.Entities;
using MediatR;

namespace BookAPI.Domain.Queries.GetBookByISBN
{
    public record GetBookByISBNQuery(string ISBN) : IRequest<Book>;
}
