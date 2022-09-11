using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Todo_App.Data;
using Microsoft.AspNetCore.Identity;
namespace Todo_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Todo_AppContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Todo_AppContext") ?? throw new InvalidOperationException("Connection string 'Todo_AppContext' not found.")));

                        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<Todo_AppContext>();
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<Todo_AppContext>();
                context.Database.EnsureCreated();
                Seed.Initialize(context);
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();;

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}