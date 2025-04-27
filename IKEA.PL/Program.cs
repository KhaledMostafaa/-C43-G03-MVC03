using IKEA.BLL.Serivces.DepartmentService;
using IKEA.BLL.Serivces.EmployeeServices;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Persistance.Data;
using IKEA.DAL.Persistance.Reposatories.Departments;
using IKEA.DAL.Persistance.Reposatories.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.IO.Compression;

namespace IKEA.PL
{
    public class Program
    
    {
        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region configure service
            // Add services to the container.
           
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IDepartmentRepositor, DepartmentRepository>();
          
            builder.Services.AddScoped<IdepartmentServices, DepartmentServices>(); 
            builder.Services.AddScoped<IEmployeeReposatoiry, EmployeeReposatiory>();

            builder.Services.AddDbContext<ApplicationDbContext>(Options=>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
              
            });
             
            builder.Services.AddScoped<IEmployeeServices, EmployeeService>();

            #endregion


            var app = builder.Build();
    



            #region configure pipline
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
               app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthorization();
            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            #endregion

            app.Run();












        }
    }
}
                                    