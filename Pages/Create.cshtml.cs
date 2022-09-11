using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Todo_App.Data;
using Todo_App.Models;

namespace Todo_App
{
    public class CreateModel : PageModel
    {
        private readonly Todo_App.Data.Todo_AppContext _context;

        public CreateModel(Todo_App.Data.Todo_AppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tasks_Dto Tasks_Dto { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Tasks_Dto == null || Tasks_Dto == null)
            {
                return Page();
            }

            _context.Tasks_Dto.Add(Tasks_Dto);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Tasks_Index");
        }
    }
}
