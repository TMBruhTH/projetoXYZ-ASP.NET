using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using projetoXYZ.Context;
using projetoXYZ.Context.Interfaces;
using projetoXYZ.Interfaces.IRepositories.IBaseRepository;
using projetoXYZ.Repository.BaseRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Projeto"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMvc();

builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient(typeof(IUnitOfWork), typeof(AppDbContext));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
