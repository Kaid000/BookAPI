using BookAPI.Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Domain.Commands.InsertBook
{
    public record AddBookCommand(string ISBN, string Title, string Description, string Author, string Genre) : IRequest<Book>;
}
