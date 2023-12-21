using AutoMapper;
using BookAPI.Data.Entities;
using BookAPI.Data.Models;
using BookAPI.Domain.Commands.InsertBook;
using BookAPI.Domain.Commands.RemoveBook;
using BookAPI.Domain.Commands.UpdateBook;
using BookAPI.Domain.Queries.GetAllBooks;
using BookAPI.Domain.Queries.GetBookById;
using BookAPI.Domain.Queries.GetBookByISBN;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public BookController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        ///     Get all books
        /// </summary>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server error</response>
        [HttpGet, Authorize]
        public async Task<List<Book>> GetAllBooks()
        {
            return await _mediator.Send(new GetAllBooksQuery());
        }

        /// <summary>
        ///     Get book by id
        /// </summary>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server error</response>
        [HttpGet("id"), Authorize]
        public async Task<Book> GetBookById(int id)
        {
            return await _mediator.Send(new GetBookByIdQuery(id));
        }

        /// <summary>
        ///     Get book by ISBN
        /// </summary>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server error</response>
        [HttpGet("ISBN"), Authorize]
        public async Task<Book> GetBookByISBN(string ISBN)
        {
            return await _mediator.Send(new GetBookByISBNQuery(ISBN));
        }

        /// <summary>
        ///     Add book to database
        /// </summary>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server error</response>
        [HttpPost, Authorize]
        public async Task<Book> AddBook(string ISBN, string Title, string Description, string Author, string Genre)
        {
            return await _mediator.Send(new AddBookCommand(ISBN, Title, Description, Author, Genre));
        }

        /// <summary>
        ///    Change info about book
        /// </summary>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server error</response>
        [HttpPut("{id}"), Authorize]
        public async Task<Book> UpdateBook(int id, BookDTO book)
        {
            var mapbook = _mapper.Map<BookDTO, Book>(book);
            return await _mediator.Send(new UpdateBookCommand(id, mapbook));
        }

        /// <summary>
        ///    Remove a book from database database
        /// </summary>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="403">Forbidden</response>
        /// <response code="500">Internal Server error</response>
        [HttpDelete("{id}"), Authorize]
        public async Task<Book> DeleteBook(int id)
        {
            return await _mediator.Send(new RemoveBookCommand(id));
        }
    }
}