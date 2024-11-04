using Car_oop.Contracts;
using Car_oop.Repository;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

//Middleware для репезитория 
var connectionString = builder.Configuration.GetConnectionString("defaultConnection");
builder.Services.AddDbContextPool<RepositoryContext>(
    options =>options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IClientsRepository,ClientRepository>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.MapControllers();

app.UseAuthorization();

app.Run();
