using BussinessLogic.Intefraces;
using BussinessLogic.Services;
using Data.Data;
using Data.Models;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connStr = builder.Configuration.GetConnectionString("LocalDb");

builder.Services.AddDbContext<WebForumDbContext>(options => options.UseSqlServer(connStr));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<WebForumDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IReplyService, ReplyService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ITopicService, TopicService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(
    builder => builder
        .WithOrigins("https://localhost:3000")
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .AllowAnyMethod()
        .AllowAnyHeader()
);

app.UseAuthorization();

app.MapControllers();

app.Run();