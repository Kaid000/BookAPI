using BookAPI.Data.Entities;
using MediatR;

namespace BookAPI.Domain.Commands.RemoveBook
{
    public record RemoveBookCommand(int Id) : IRequest<Book>;
}
