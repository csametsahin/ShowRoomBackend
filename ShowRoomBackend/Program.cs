    using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog.Events;
using Serilog;
using SR.Business.DependencyResolver.Autofac;
using SR.Core.DependencyResolver;
using SR.Core.Extensions;
using SR.Core.Utilities.IoC;
using SR.DataAccess.Concrete.Contexts;
using System.Globalization;
using Serilog.Sinks.MSSqlServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Jwt Config
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["AppSettings:ValidIssuer"],
        ValidAudience = builder.Configuration["AppSettings:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Secret"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
    };
});

builder.Services.AddAuthorization();
// localization
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new("tr-TR");
    CultureInfo[] cultures = new CultureInfo[]
    {
        new("tr-TR"),
        new("en-US"),
        new("fr-FR")
    };

    options.SupportedCultures = cultures;
    options.SupportedUICultures = cultures;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptions();

#region add auto mapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion

var connectionString = builder.Configuration.GetSection("ConnectionStrings:SRConnectionString").Value;

#region logger
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .WriteTo.Debug(LogEventLevel.Information)
    .WriteTo.MSSqlServer(connectionString: connectionString, sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true })
    .CreateLogger();
builder.Host.UseSerilog(logger);

#endregion


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));
builder.Services
    .AddDbContext<SRContext>(_ => _.UseSqlServer(connectionString))
    .AddDependencyResolvers(new ICoreModule[]
    {
        new CoreModule()
    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRequestLocalization();
app.UseAuthorization();

app.UseSerilogRequestLogging();


app.MapControllers();

app.Run();
