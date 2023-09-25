using BlogV_005.Data;
using BlogV_005.Models;
using BlogV_005.Services;
using BlogV_005.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder; // Add this for UseMigrationsEndPoint
using Microsoft.AspNetCore.Hosting; // Add this for app.Environment
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Identity Configuration
builder.Services.AddIdentity<BlogUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddDefaultUI()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Other services
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Data services
builder.Services.AddScoped<DataServices>();

// Configure mail settings
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddScoped<IBlogEmailSender, EmailService>();

//Image services
builder.Services.AddScoped<IImageService, BasicImageService>();

//Slug service
builder.Services.AddScoped<ISlugService, BasicSlugService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint(); // For development environment
}
else
{
    app.UseExceptionHandler("/Home/Error"); // For production environment
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Run DataServices
var dataService = app.Services
                     .CreateScope()
                     .ServiceProvider
                     .GetRequiredService<DataServices>();
await dataService.ManageDataAsync();



// Map default routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
