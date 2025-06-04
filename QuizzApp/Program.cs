using Microsoft.EntityFrameworkCore;
using QuizzApp.Data;
using QuizzApp.Repository;
using QuizzApp.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<QuizDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<QuizResultRepository>();
builder.Services.AddScoped<QuizResultService>();
builder.Services.AddScoped<QuizRepository>();
builder.Services.AddScoped<QuizService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserAnswerService>();
builder.Services.AddScoped<UserAnswerRepository>();
builder.Services.AddScoped<QuestionRepository>();
builder.Services.AddScoped<QuestionService>();
builder.Services.AddScoped<AnswerOptionRepository>();
builder.Services.AddScoped<AnswerOptionService>();

var app = builder.Build();





app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
