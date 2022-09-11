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
    public class IndexModel : PageModel
    {
        private readonly Todo_App.Data.Todo_AppContext _context;

        public IndexModel(Todo_App.Data.Todo_AppContext context)
        {
            _context = context;
        }

        public IList<Tasks_Dto> Tasks_Dto { get;set; } = default!;

        public void OnGet()
        {
            Tasks_Dto = _context.Tasks_Dto
            //You have to convert your IQueryable to a List. You can do this by adding .ToList() at the end of
            //your Linq query.
            //Also change the type as <Lease>. Try this query instead,
            .Where(t => t.Ref_User_name == User!.Identity!.Name).OrderBy(t => t.Task).ToList();
            Tasks_Dto = Tasks_Dto.ToList();
        }
    }
}
