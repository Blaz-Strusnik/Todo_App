using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Todo_App.Data;
using Todo_App.Models;

namespace Todo_App
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly Todo_App.Data.Todo_AppContext _context;

        public DeleteModel(Todo_App.Data.Todo_AppContext context)
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

            var tasks_dto = await _context.Tasks_Dto.FirstOrDefaultAsync(m => m.Id == id);

            if (tasks_dto == null)
            {
                return NotFound();
            }
            else 
            {
                Tasks_Dto = tasks_dto;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.Tasks_Dto == null)
            {
                return NotFound();
            }
            var tasks_dto = await _context.Tasks_Dto.FindAsync(id);

            if (tasks_dto != null)
            {
                Tasks_Dto = tasks_dto;
                _context.Tasks_Dto.Remove(Tasks_Dto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Tasks_Index");
        }
    }
}
