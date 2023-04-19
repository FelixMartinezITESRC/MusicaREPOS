using Microsoft.EntityFrameworkCore;
using MusicaApi.Data;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<Sistem21MusicaContext>(x => x.UseMySql("server=sistemas19.com;user=sistem21_musica;password=sistemas19_;database=sistem21_musica", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.17-mariadb")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                          policy.AllowAnyOrigin();
                      });
});

var app = builder.Build();

app.UseRouting();

app.MapControllers();

app.UseCors(MyAllowSpecificOrigins);

app.Run();
