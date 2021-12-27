#nullable disable
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
    public class IndexModel : PageModel
    {
        private readonly AddressBookWebApp.Data.ApplicationDbContext _context;

        public IndexModel(AddressBookWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AddressBook> AddressBook { get;set; }

        public async Task OnGetAsync()
        {
            AddressBook = await _context.AddressBook.ToListAsync();
        }
    }
}
