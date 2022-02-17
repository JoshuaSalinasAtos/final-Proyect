using AutoMapper;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using WebBackEndLibrary.Dtos;
using WebBackEndLibrary.Models;
using WebBackEndLibrary.Services;

namespace WebBackEndLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController :ControllerBase
    {
        private readonly IBookService _BookService;

        public BookController(IBookService BookService)
        {
            _BookService = BookService;
        }
        //Get: api/Book
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<BookDto> Book = await _BookService.FindAll();
            return Ok(Book);
        }
        //Get api/Book/Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            BookDto? BookDto = await _BookService.FindById(id);
            return BookDto != null ? Ok(BookDto) : NotFound();
        }

        //Post create
        [HttpPost]
        public async Task<IActionResult> Create(BookDto BookDto)
        {
            try
            {
                await _BookService.Insert(BookDto);
                return Created(Request.GetDisplayUrl(), BookDto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        //Put update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BookDto BookDto)
        {
            if (id != BookDto.Id) return BadRequest();
            _BookService.Update(BookDto);
            return NoContent();
        }
    }
}
