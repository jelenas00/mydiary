using MyDiary.Models;
using MyDiary.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MyDiaryDatabaseSettings>(builder.Configuration.GetSection("MyDiaryDatabase"));
// Add services to the container.
builder.Services.AddSingleton<UsersService>();
builder.Services.AddSingleton<DiariesService>();
builder.Services.AddSingleton<PagesService>();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
                      policy  =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});
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

app.UseCors("MyAllowSpecificOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
