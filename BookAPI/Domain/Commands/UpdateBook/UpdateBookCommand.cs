using BookAPI.Data.Entities;
using BookAPI.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Domain.Commands.UpdateBook
{
    public record UpdateBookCommand(int Id, [FromBody] Book book) : IRequest<Book>;
}
