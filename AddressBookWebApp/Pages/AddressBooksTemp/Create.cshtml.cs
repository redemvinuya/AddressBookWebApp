#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AddressBookWebApp.Data;
using AddressBookWebApp.Model;

namespace AddressBookWebApp.Pages.AddressBooksTemp
{
    public class CreateModel : PageModel
    {
        private readonly AddressBookWebApp.Data.ApplicationDbContext _context;

        public CreateModel(AddressBookWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AddressBook AddressBook { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AddressBook.Add(AddressBook);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
