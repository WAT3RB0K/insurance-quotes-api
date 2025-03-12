using InsuranceQuoteApp.Data;
using Microsoft.EntityFrameworkCore;
using InsuranceQuoteApp.Data.Repositories;
using InsuranceQuoteApp.BusinessLogic.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configuration and Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext using connection string from API's appsettings.json
builder.Services.AddDbContext<InsuranceQuoteAppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsAssembly("InsuranceQuoteApp.Data")));

// Register repository and service layers
builder.Services.AddScoped<IInsuranceQuoteRepository, InsuranceQuoteRepository>();
builder.Services.AddScoped<IInsuranceQuoteService, InsuranceQuoteService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

// Add controllers
builder.Services.AddControllers();

// Ensure the app listens on the correct URL for Docker
builder.WebHost.UseUrls("http://0.0.0.0:80");

// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// })
// .AddJwtBearer(options =>
// {
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuer = true,
//         ValidateAudience = true,
//         ValidateLifetime = true,
//         ValidateIssuerSigningKey = true,
//         ValidIssuer = builder.Configuration["Jwt:Issuer"],
//         ValidAudience = builder.Configuration["Jwt:Audience"],
//         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//     };
// });


var app = builder.Build();

// Middleware configuration
app.UseHttpsRedirection();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();

// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapGet("/", async context =>
//     {
//         context.Response.Redirect("/swagger");
//     });
// });

