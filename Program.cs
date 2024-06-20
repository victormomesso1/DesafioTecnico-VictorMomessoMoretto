using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using API_RandomUser.Context;
using API_RandomUser.Interfaces;
using API_RandomUser.Repositories;
using API_RandomUser.Services;
using API_RandomUser.Token;
using NLog.Web;
using NLog;

var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var connectionString = "Host=localhost;Port=5432;Database=teste3;Username=postgres;Password=1234;";
    builder.Services.AddScoped<AppDbContext>(provider => new AppDbContext(connectionString));

    
    builder.Services.AddTransient<IDobRepository, DobRepository>();
    builder.Services.AddTransient<INameRepository, NameRepository>();
    builder.Services.AddTransient<ILocationRepository, LocationRepository>();
    builder.Services.AddTransient<ILoginRepository, LoginRepository>();
    builder.Services.AddTransient<IRegisteredRepository, RegisteredRepository>();
    builder.Services.AddTransient<IIDRepository, IdRepository>();
    builder.Services.AddTransient<IPictureRepository, PictureRepository>();
    builder.Services.AddTransient<IUserRepository, UserRepository>();
    builder.Services.AddTransient<IRegisterTokenRepository, RegisterTokenRepository>(); 
    

    
    builder.Services.AddTransient<IUserService, UserService>();
    builder.Services.AddSingleton<JwtService>();

   
    var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:Secret"]);
    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseCors(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });

    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
catch (Exception exception)
{
    logger.Error(exception, "Parou o programa devido a uma exceção");
    throw;
}
finally
{
    LogManager.Shutdown();
}