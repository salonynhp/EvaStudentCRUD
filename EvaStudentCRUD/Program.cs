using Microsoft.EntityFrameworkCore;
using Student.Entity.Models;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Student.Repository.Common;
using Student.Business.Contract;
using Student.Repository.Contract;
using Student.Repository.Repository;
using Student.ViewModels.ViewModels;
using Student.ViewModels;
using Newtonsoft;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args); //services are added to DI container by this webApplicationBuilder

var configuration = builder.Configuration; //Added to get Configuration from appsettings.json

// Add services to the container.
builder.Services.AddScoped<DbContext, StudentCrudContext>();
builder.Services.AddScoped<IStudentBusiness, StudentBusiness>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();


builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//To use connectionString for Db connections (EF).
builder.Services.AddDbContext<StudentCrudContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("StudentCRUDConnectionString"));
});


//To use Automapper. provide assembly name(profile)
builder.Services.AddAutoMapper(c => {
    c.AddExpressionMapping();
}, typeof(AutoMapperProfiles).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.: Middlewares ...Use[feature]...
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}  

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//-------------------------------------------------------------------------------------------
//Configuiring AutoMapper( <source, destination>());
//var config = new MapperConfiguration(cfg => cfg.CreateMap<Studentdetail, StudentView>());
//Initializing Automapper: pass mapper config to constructor of mapper
//var mapper = new Mapper(config);
