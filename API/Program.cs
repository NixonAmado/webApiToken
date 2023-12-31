using API.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors();
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddDbContext<TokenApiContext>(options =>
    {
        string connectionString = builder.Configuration.GetConnectionString("conexMySql");
        options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
    }

);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
}
//midware
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
