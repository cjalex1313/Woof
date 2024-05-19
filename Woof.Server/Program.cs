using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Woof.BusinessLogic;
using Woof.DataAccess;
using Woof.Domain.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();
if (appSettings == null)
{
    throw new Exception("Config is corrupt");
}
builder.Services.AddSingleton<AppSettings>(appSettings);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddBusinessLogic(builder.Configuration);
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<WoofDbContext>().AddDefaultTokenProviders();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = true;
    var jwtSecret = appSettings.JWTConfig.Secret;
    if (string.IsNullOrWhiteSpace(jwtSecret))
    {
        throw new Exception("Invalid JWT config");
    }
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidAudience = appSettings.JWTConfig.ValidAudience,
        ValidIssuer = appSettings.JWTConfig.ValidIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
    };
});
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var woofDbContxt = scope.ServiceProvider.GetService<WoofDbContext>();
    if (woofDbContxt == null)
    {
        throw new Exception("Cannot initialize dbContext");
    }
    woofDbContxt.Database.Migrate();
}

app.Run();
