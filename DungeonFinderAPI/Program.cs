using DungeonFinderDomain.Interface.Repository;
using DungeonFinderInfra.DbConnect;
using DungeonFinderInfra.Repository;

var builder = WebApplication.CreateBuilder(args);

//Dependency Injection
builder.Services.AddScoped<DbSession>();
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
