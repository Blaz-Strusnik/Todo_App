namespace Todo_App.Data
{
    public class Seed
    {
        public static void Initialize(Todo_AppContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Tasks_Dto.Any())
            {
                return;   // DB has been seeded
            }

            var tasks = new Todo_App.Models.Tasks_Dto[]
            {
           
                new Todo_App.Models.Tasks_Dto
                {
                    Task = "ASP.NET Core Project managemnt app",
                    Description = "Project management app",
                    StartDate  = DateTime.ParseExact("2023-2-2 09:00","yyyy-M-d HH:mm",null),
                    EndDate  = DateTime.ParseExact("2023-2-2 09:00","yyyy-M-d HH:mm",null),
                    Ref_User_name = "a@a.a"

                },
                new Todo_App.Models.Tasks_Dto
                {
                    Task = "Project presentation",
                    Description = "Project presentation prep",
                    StartDate  = DateTime.ParseExact("2023-6-24 09:00","yyyy-M-d HH:mm",null),
                    EndDate  = DateTime.ParseExact("2023-6-24 09:00","yyyy-M-d HH:mm",null),
                    Ref_User_name = "b@b.b"

        },
                new Todo_App.Models.Tasks_Dto
                {
                    Task = "Emails",
                    Description = "Check and reply to emails",
                    StartDate  = DateTime.ParseExact("2023-4-30 09:00","yyyy-M-d HH:mm",null),
                    EndDate  = DateTime.ParseExact("2023-4-30 09:00","yyyy-M-d HH:mm",null),
                    Ref_User_name = "b@b.b"
                },
                new Todo_App.Models.Tasks_Dto
                {
                    Task = ".NET Calendar",
                    Description = "Start planing calendar app tasks",
                    StartDate  = DateTime.ParseExact("2023-5-27 09:00","yyyy-M-d HH:mm",null),
                    EndDate  = DateTime.ParseExact("2023-5-27 09:00","yyyy-M-d HH:mm",null),
                    Ref_User_name = "b@b.b"
                },
                new Todo_App.Models.Tasks_Dto
                {
                    Task = "Gantt charts",
                    Description = "Plan for imeplemneting a gantt chart",
                    StartDate  = DateTime.ParseExact("2023-3-24 09:00","yyyy-M-d HH:mm",null),
                    EndDate  = DateTime.ParseExact("2023-3-24 09:00","yyyy-M-d HH:mm",null),
                    Ref_User_name = "a@a.a"
                },
                new Todo_App.Models.Tasks_Dto
                {
                    Task = "ASP.NET Core Todo app design",
                    Description = "Plan for updating Todo app UI",
                    StartDate  = DateTime.ParseExact("2023-5-10 09:00","yyyy-M-d HH:mm",null),
                    EndDate  = DateTime.ParseExact("2023-5-10 09:00","yyyy-M-d HH:mm",null),
                    Ref_User_name = "a@a.a"
                },
                new Todo_App.Models.Tasks_Dto
                {
                    Task = "ASP.NET Core ReactJS App",
                    Description = "Make a plan for building a ASP.NET Core ReactJS App",
                    StartDate  = DateTime.ParseExact("2023-5-7 09:00","yyyy-M-d HH:mm",null),
                    EndDate  = DateTime.ParseExact("2023-5-7 09:00","yyyy-M-d HH:mm",null),
                    Ref_User_name = "b@b.b"
                }
           
            };
            foreach (Todo_App.Models.Tasks_Dto n in tasks)
            {
                context.Tasks_Dto.Add(n);
            }
            context.SaveChanges();
        }
    }
}
