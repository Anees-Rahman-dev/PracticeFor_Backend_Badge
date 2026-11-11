using B_Review_Application.Interface;
using B_Review_Application.Service;
using B_Review_Application.StudentService;
using B_Review_Infrastructure.Data;
using B_Review_Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PracticeFor_B_Review.Setting;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Student CRUD
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<StudentService>();

// User CRUD - ADO.NET
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

//Employee
builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();
builder.Services.AddScoped<IEmployeesService,EmployeesService>();

builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("Jwt"));

builder.Services.AddDbContext<ApplicationDBContext>(options =>
  options.UseSqlServer(
      builder.Configuration.GetConnectionString("DefaultConnection")));


//JWT
builder.Services.
    AddAuthentication(options => //"We are going to use an authentication system in this application."
    {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    // Tells ASP.NET Core which authenticaation mechanism to use when identifying the user. (using JWT Bearer Auth)
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
})

    .AddJwtBearer(options =>
    {//This configures how incoming JWT tokens should be validated.
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,//is the token issued by the expected issuer?
            ValidateAudience = true,//is the token inteded for this API?
            ValidateLifetime = true,//has the token expired?
            ValidateIssuerSigningKey = true,//is the signing key valid?

            ValidIssuer = builder.Configuration["Jwt:Issuer"],//Expected Issuer
            ValidAudience = builder.Configuration["Jwt:Audience"],//Expected Audience

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes( //Key used to verify the signature.
                    builder.Configuration["Jwt:Key"]!
                    ))
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
