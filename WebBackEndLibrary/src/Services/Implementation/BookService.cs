using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using WebBackEndLibrary.Dtos;
using WebBackEndLibrary.Models;
using WebBackEndLibrary.Repositories;

namespace WebBackEndLibrary.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<List<BookDto>> FindAll()
        {
            List<Book> book = await _bookRepository.FindAll();
            return _mapper.Map<List<Book>,List<BookDto>>(book);
        }

        public async Task<BookDto?> FindById(int id)
        {
            Book? book = await _bookRepository.FindById(id);
            return book == null ? null : _mapper.Map<Book, BookDto>(book);
        }
        public async Task<BookDetailsDto?> FindByIdDetails(int id)
        {
            Book? book = await _bookRepository.FindById(id);
            return book == null ? null : _mapper.Map<Book, BookDetailsDto>(book);
        }

        public async Task Insert(BookDto bookDto)
        {
            Book book = _mapper.Map<BookDto, Book>(bookDto);
            _bookRepository.Insert(book);
            await Save();
        }

        public async Task Delete(int id)
        {
            await _bookRepository.Delete(id);
            await _bookRepository.Save();
        }

        public void Update(BookDto bookDto)
        {
            Book book = _mapper.Map<BookDto, Book>(bookDto);
            _bookRepository.Update(book);
        }

        public async Task<int> Save()
        {
            return await _bookRepository.Save();
        }
    }
}