using SmartNotepad.Data.Context;
using SmartNotepad.Data.Repositories.Repositories;
using SmartNotepad.Data.Repositories.Repositories.Implementation;
using SmartNotepad.Domain.Services.Services;
using SmartNotepad.Domain.Services.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();

builder.Services.AddScoped<IBoardService, BoardService>();
builder.Services.AddScoped<IBoardRepository, BoardRepository>();

builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();

builder.Services.AddScoped<IRecipesService, RecipesService>();
builder.Services.AddScoped<IRecipesRepository, RecipesRepository>();

builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers().RequireCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.Run();
