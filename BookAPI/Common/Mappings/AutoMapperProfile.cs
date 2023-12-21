using AutoMapper;
using BookAPI.Data.Entities;
using BookAPI.Data.Models;

namespace BookAPI.Common.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDTO>();

            CreateMap<BookDTO, Book>();
        }
    }
}
