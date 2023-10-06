using GlassCoreWebAPI.Interface;
using GlassCoreWebAPI.Models;
using GlassCoreWebAPI.Repositories;
using GlassCoreWebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
}); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder
                .WithOrigins("*") 
                .AllowAnyMethod() 
                .AllowAnyHeader(); 
        });
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IRepository<Aula>, Repository<Aula>>();
builder.Services.AddScoped<IRepository<Carrera>, Repository<Carrera>>();
builder.Services.AddScoped<IRepository<Area>, Repository<Area>>();

builder.Services.AddScoped<IRepository<Estudiante>, Repository<Estudiante>>();
builder.Services.AddScoped<IRepository<Usuario>, Repository<Usuario>>();
builder.Services.AddScoped<IRepository<Profesor>, Repository<Profesor>>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<AulaService>();
builder.Services.AddScoped<AreaService>();

builder.Services.AddScoped<CarreraService>();
builder.Services.AddScoped<ProfesorService>();

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<EstudianteService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
}

);

builder.Services.AddDbContext<GlassCoreContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("GlassCoreAPI")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
