using AutoMapper;
using WebBackEndLibrary.Dtos;
using WebBackEndLibrary.Models;

namespace WebBackEndLibrary.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //source -> Target
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
            //Dto -> Grpc
            //CreateMap<BookDto, api.Grpc.Book>();
        }
    }
}