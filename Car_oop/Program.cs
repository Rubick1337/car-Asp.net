using Car_oop.Contracts;
using Car_oop.Interface;
using Car_oop.Middleware;
using Car_oop.Repository;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

//Middleware ��� ����������� 
var connectionString = builder.Configuration.GetConnectionString("defaultConnection");
builder.Services.AddDbContextPool<RepositoryContext>(
    options =>options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));

//����������� �����������
builder.Services.AddScoped<IClientsRepository,ClientRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IModelCarRepository, ModelCarRepository>();
builder.Services.AddScoped<IPersonalRepository, PersonalRepository>();
//���������� Automapper  �������� typeof(Program) ������������ ��� �������� ������ ��� ������������ ���,
//��� AutoMapper ������ ������ ������� ��������
builder.Services.AddAutoMapper(typeof(Program));
//���������� swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
//����������� Middlaware ��� ����������
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
    //���������� Get ������� ��������������� �� swagger
    app.MapGet("/", () => Results.Redirect("/swagger"));
}
app.UseStaticFiles();

app.MapControllers();

app.UseAuthorization();

app.Run();
