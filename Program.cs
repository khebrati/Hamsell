using Hamsell.Data;
using Hamsell.Data.Repositories.Post;
using Hamsell.Data.Repositories.User;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddSingleton<DbContext>(serviceProvider =>
{
    var configuration = serviceProvider.GetService<IConfiguration>();
    var server = configuration["Database:Server"];
    var databaseName = configuration["Database:DatabaseName"];
    var userName = configuration["Database:UserName"];
    var password = configuration["Database:Password"];

    return new DbContext(server, databaseName, userName, password);
});
builder.Services.AddTransient<UserRepository>(
    serviceProvider => new UserRepository(serviceProvider.GetService<DbContext>()));
builder.Services.AddTransient<PostRepository>(
    serviceProvider => new PostRepository(serviceProvider.GetService<DbContext>()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseSession();
app.Run();