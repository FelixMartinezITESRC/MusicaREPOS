using Microsoft.EntityFrameworkCore;
using MusicaApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<Sistem21MusicaContext>(x => x.UseMySql("server=sistemas19.com;user=sistem21_musica;password=sistemas19_;database=sistem21_musica", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.17-mariadb")));

var app = builder.Build();

app.UseRouting();

app.MapControllers();

app.Run();
