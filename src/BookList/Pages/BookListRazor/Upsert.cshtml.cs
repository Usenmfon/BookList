using System.Threading.Tasks;
using BookList.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookList.Pages.BookListRazor
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new Book();
            if (id == null)
            {
                return Page();
            }

            Book = await _db.Book.FirstOrDefaultAsync(u => u.Id == id);
            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
               var BookFromDb = await _db.Book.FindAsync(Book.Id);
               BookFromDb.Name = Book.Name;
               BookFromDb.ISBN = Book.ISBN;
               BookFromDb.Author = Book.Author;

               await _db.SaveChangesAsync();

               return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
    
}