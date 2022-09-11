using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Todo_App.Data;
using Todo_App.Models;

namespace Todo_App
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly Todo_App.Data.Todo_AppContext _context;

        public EditModel(Todo_App.Data.Todo_AppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tasks_Dto Tasks_Dto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Tasks_Dto == null)
            {
                return NotFound();
            }

            var tasks_dto =  await _context.Tasks_Dto.FirstOrDefaultAsync(m => m.Id == id);
            if (tasks_dto == null)
            {
                return NotFound();
            }
            Tasks_Dto = tasks_dto;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Tasks_Dto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tasks_DtoExists(Tasks_Dto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Tasks_Index");
        }

        private bool Tasks_DtoExists(long id)
        {
          return (_context.Tasks_Dto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
