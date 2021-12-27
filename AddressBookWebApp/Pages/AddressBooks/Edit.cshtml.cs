using AddressBookWebApp.Data;
using AddressBookWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AddressBookWebApp.Pages.AddressBooks
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public AddressBook AddressBook { get; set; }

        public EditModel(ApplicationDbContext db)
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
            if (AddressBook.Name == AddressBook.Address)
            {
                ModelState.AddModelError("AddressBook.Name", "The Name cannot exactly match the Address.");
            }
            if (AddressBook.Name == AddressBook.PhoneNumber.ToString())
            {
                ModelState.AddModelError("AddressBook.PhoneNumber", "The Phone Number cannot exactly match the Name.");
            }
            if (AddressBook.Address == AddressBook.PhoneNumber)
            {
                ModelState.AddModelError("AddressBook.Address", "The Address cannot exactly match the Phone Number.");
            }
            if (ModelState.IsValid)
            {
                _db.AddressBook.Update(AddressBook);
                _db.SaveChangesAsync();
                TempData["success"] = "Address Book updated succesfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
