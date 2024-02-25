using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactFinalApi.Models;

namespace ReactFinalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookDbContext _bookDbContext;

        public BookController(BookDbContext studentDbContext)
        {
            this._bookDbContext = studentDbContext;
        }

        [HttpGet]
        [Route("GetBook")]

        public async Task<IEnumerable<Book>> GetStudents()
        {
            return await _bookDbContext.Books.ToListAsync();
        }

        [HttpPost]
        [Route("AddBook")]

        public async Task<Book> AddStudent(Book book)
        {
            await _bookDbContext.Books.AddAsync(book);
            await _bookDbContext.SaveChangesAsync();
            return book;
        }

        [HttpPatch]
        [Route("UpdateBook/{id}")]

        public async Task<Book> UpdateStudent(Book student)
        {
            _bookDbContext.Entry(student).State = EntityState.Modified;
            await _bookDbContext.SaveChangesAsync();
            return student;
        }

        [HttpDelete]
        [Route("DeleteBook/{id}")]

        public bool DeleteStudent(int id)
        {
            bool a = false;
            var student = _bookDbContext.Books.Find(id);
            if (student != null)
            {
                a=true;
                _bookDbContext.Entry(student).State=EntityState.Deleted;
                _bookDbContext.SaveChangesAsync();

            }

            else
            {
                a=false;
            }
            return a;
        }
    }
}
