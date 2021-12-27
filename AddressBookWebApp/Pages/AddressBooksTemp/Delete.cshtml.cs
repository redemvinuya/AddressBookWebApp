﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AddressBookWebApp.Data;
using AddressBookWebApp.Model;

namespace AddressBookWebApp.Pages.AddressBooksTemp
{
    public class DeleteModel : PageModel
    {
        private readonly AddressBookWebApp.Data.ApplicationDbContext _context;

        public DeleteModel(AddressBookWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddressBook AddressBook { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AddressBook = await _context.AddressBook.FirstOrDefaultAsync(m => m.Id == id);

            if (AddressBook == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AddressBook = await _context.AddressBook.FindAsync(id);

            if (AddressBook != null)
            {
                _context.AddressBook.Remove(AddressBook);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
