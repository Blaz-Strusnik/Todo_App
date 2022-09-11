using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Todo_App.Models;

namespace Todo_App.Data
{
    public class Todo_AppContext : IdentityDbContext<IdentityUser>
    {
        public Todo_AppContext (DbContextOptions<Todo_AppContext> options)
            : base(options)
        {
        }

        public DbSet<Todo_App.Models.Tasks_Dto> Tasks_Dto { get; set; } = default!;
    }
}
