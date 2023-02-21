using AV22YRGO.web.Data;
using Microsoft.EntityFrameworkCore;
using WestCoastEdu.web.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AvYrgoContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"))
);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<AvYrgoContext>();
    await context.Database.MigrateAsync();
    await SeedData.LoadCourseData(context);
    await SeedData.LoadAccountData(context);
}
catch (Exception ex)
{
    Console.WriteLine("{0} - {1}", ex.Message, ex.InnerException!.Message);
    throw;
}

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
