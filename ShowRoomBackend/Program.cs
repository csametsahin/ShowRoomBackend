using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SR.Business.DependencyResolver.Autofac;
using SR.Core.DependencyResolver;
using SR.Core.Extensions;
using SR.Core.Utilities.IoC;
using SR.DataAccess.Concrete.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptions();



var connectionString = builder.Configuration.GetSection("ConnectionStrings:SRConnectionString").Value;

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

app.UseAuthorization();

app.MapControllers();

app.Run();
