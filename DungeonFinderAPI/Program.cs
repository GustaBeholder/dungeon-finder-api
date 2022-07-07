using DungeonFinderAPI.Interface;
using DungeonFinderAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

string connString = builder.Configuration.GetConnectionString("DefaultConnection");

//Dependency Injection
builder.Services.AddScoped<IMesaRepository, MesaRepository>();
// Add services to the container.
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

app.UseAuthorization();

app.MapControllers();

app.Run();
