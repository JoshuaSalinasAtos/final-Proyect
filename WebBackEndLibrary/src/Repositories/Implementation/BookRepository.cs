using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebBackEndLibrary.Configurations;
using WebBackEndLibrary.Models;

namespace WebBackEndLibrary.Repositories.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly EntityContext _entityContext;

        public BookRepository(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        public async Task<List<Book>> FindAll()
        {
            return await _entityContext.Books.ToListAsync();
        }

        public async Task<Book?> FindById(int id)
        {
            return await _entityContext.Books.FindAsync(id);
        }
        

        public void Insert(Book book)
        {
            _entityContext.Books.Add(book);
        }

        public async Task Delete(int id)
        {
            Book? toDelete = await FindById(id);
            _entityContext.Books.Remove(toDelete!);
        }

        public void Update(Book book)
        {
            _entityContext.Books.Update(book);
        }

        public async Task<int> Save()
        {
            return await _entityContext.SaveChangesAsync();
        }

    }
}