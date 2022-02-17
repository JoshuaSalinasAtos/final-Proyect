using System.Collections.Generic;
using System.Threading.Tasks;
using WebBackEndLibrary.Dtos;
using WebBackEndLibrary.Models;

namespace WebBackEndLibrary.Services
{
    public interface IBookService
    {
        Task<List<BookDto>> FindAll();
        Task<BookDto?> FindById(int id);
        Task<BookDetailsDto?> FindByIdDetails(int id);
        Task Insert(BookDto book);
        Task Delete(int id);
        void Update(BookDto book);
        Task<int> Save();
    }
}