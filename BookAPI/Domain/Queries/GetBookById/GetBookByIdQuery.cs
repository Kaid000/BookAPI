using BookAPI.Data.Entities;
using MediatR;

namespace BookAPI.Domain.Queries.GetBookById
{
    public record GetBookByIdQuery(int Id) : IRequest<Book>;
}
