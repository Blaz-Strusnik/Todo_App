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
    public class DetailsModel : PageModel
    {
        private readonly Todo_App.Data.Todo_AppContext _context;

        public DetailsModel(Todo_App.Data.Todo_AppContext context)
        {
            _context = context;
        }

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
    }
}
