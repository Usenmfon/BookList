using System.Collections.Generic;
using System.Threading.Tasks;
using BookList.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookList.Pages.BookListRazor
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Book> Books { get; set; }
        
        
        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();           
        }
    }
}
