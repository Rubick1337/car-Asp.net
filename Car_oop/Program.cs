using Car_oop.Contracts;
using Car_oop.Interface;
using Car_oop.Middleware;
using Car_oop.Repository;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

//Middleware для репезитория 
var connectionString = builder.Configuration.GetConnectionString("defaultConnection");
builder.Services.AddDbContextPool<RepositoryContext>(
    options =>options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));

//подключение репезитории
builder.Services.AddScoped<IClientsRepository,ClientRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IModelCarRepository, ModelCarRepository>();
builder.Services.AddScoped<IPersonalRepository, PersonalRepository>();
//добавление Automapper  параметр typeof(Program) используется для указания сборки или пространства имён,
//где AutoMapper должен искать профили маппинга
builder.Services.AddAutoMapper(typeof(Program));
//добавление swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
//Подключение Middlaware для исключений
app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

}
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //Выполнение Get запроса перенаправление на swagger
    app.MapGet("/", () => Results.Redirect("/swagger"));
}
app.UseStaticFiles();

app.MapControllers();

app.UseAuthorization();

app.Run();
