using DataAccessLayer;
using BusinessLogicLayer;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuestionAnswer.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<QuestionAnswerContextDB>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("QuestionAnswer")));

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<QuestionBLL, QuestionModel>().ReverseMap();
    cfg.CreateMap<AnswerBLL, AnswerModel>().ReverseMap();
    cfg.CreateMap<CategoryBLL, CategoryModel>().ReverseMap();
});

var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<BLL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
