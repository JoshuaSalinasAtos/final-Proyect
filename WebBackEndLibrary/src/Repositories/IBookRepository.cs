using System.Collections.Generic;
using System.Threading.Tasks;
using WebBackEndLibrary.Models;

namespace WebBackEndLibrary.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> FindAll();
        Task<Book?> FindById(int id);
        void Insert(Book Book);
        Task Delete(int id);
        void Update(Book Book);
        Task<int> Save();
    }
}