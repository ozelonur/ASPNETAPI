using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using KPSS.API.Filters;
using KPSS.API.Middlewares;
using KPSS.API.Modules;
using KPSS.Repository;
using KPSS.Service.Mapping;
using KPSS.Service.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute()));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<ProductDtoValidator>();

builder.Services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"),
        options => { options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext))?.GetName().Name); });
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    containerBuilder.RegisterModule(new RepoServiceModule()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();