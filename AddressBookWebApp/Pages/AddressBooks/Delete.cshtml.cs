using AddressBookWebApp.Data;
using AddressBookWebApp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AddressBookWebApp.Pages.AddressBooks
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public AddressBook AddressBook { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public void OnGet(int id)
        {
            AddressBook = _db.AddressBook.Find(id);
            //AddressBook = _db.AddressBook.FirstOrDefault( u => u.Id == id ); if nothing is found, will return null. If Find only and nothing is found, will return an exception
            //AddressBook = _db.AddressBook.Single(id); use if there is only one entity. if nothing is found, will return an exception
            //AddressBook = _db.AddressBook.SingleOrDefault( u => u.Id == id ); if nothing is found, will return null
            //AddressBook = _db.AddressBook.Where( u => u.Id == id ).FirstOrDefault(); will return all matches
        }

        public async Task<IActionResult> OnPost()
        {
            var addressBookFromDb = _db.AddressBook.Find(AddressBook.Id);
            if (addressBookFromDb != null)
            {
                _db.AddressBook.Remove(addressBookFromDb);
                await _db.SaveChangesAsync();
                TempData["success"] = "Address Book deleted succesfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
