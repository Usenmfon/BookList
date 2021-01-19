using BookList.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookList.Pages.BookListRazor
{
  public class CreateModel : PageModel
  {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
      {
          _db = db;
      }
      public Book Book { get; set;}
      public void OnGet ()
      {

      }
  }
}