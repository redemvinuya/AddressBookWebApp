using AddressBookWebApp.Data;
using AddressBookWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AddressBookWebApp.Pages.AddressBooks
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IEnumerable<AddressBook> AddressBooks { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public void OnGet()
        {
            AddressBooks = _db.AddressBook;
        }
    }
}
