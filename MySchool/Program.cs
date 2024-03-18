using Microsoft.EntityFrameworkCore;
using MySchool.Core.Application.Interfaces.Repositories;
using MySchool.Core.Application.Interfaces.Services;
using MySchool.Core.Application.Services;
using MySchool.Infrastructure.Persistence.Context;
using MySchool.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StudContext>(opt => opt.UseMySQL(builder.Configuration.GetConnectionString("StudString")));
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<IGuardianRepository, GuardianRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFileRepository, FileRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGuardianService, GuardianService>();
builder.Services.AddScoped<IRoleService, RoleService>();

var app = builder.Build();

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

app.Run();
