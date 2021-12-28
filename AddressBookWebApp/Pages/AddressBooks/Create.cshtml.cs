using AddressBookWebApp.Data;
using AddressBookWebApp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AddressBookWebApp.Pages.AddressBooks
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public AddressBook AddressBook { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public void OnGet()
        {
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
                await _db.AddressBook.AddAsync(AddressBook);
                await _db.SaveChangesAsync();
                TempData["success"] = "Address Book created succesfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
