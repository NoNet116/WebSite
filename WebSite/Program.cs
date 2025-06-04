using BLL.Interfaces;
using BLL.Services;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using WebSite.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddAutoMapper(typeof(MappingProfile));

string connection = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("no string connection");

// Регистрируем контекст БД
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connection));

builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddIdentity<User, IdentityRole>(opts =>
{
    opts.Password.RequiredLength = 2;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireDigit = false;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

/*using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated(); // создает базу и таблицы, если их нет
    Console.WriteLine("EnsureCreated() выполнен");
}*/

app.MapGet("/test-users", async (AppDbContext context) =>
{
    var users = await context.Users.ToListAsync();
    return Results.Ok(users);
});

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
