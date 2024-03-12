using Microsoft.EntityFrameworkCore.Internal;
using System.Drawing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SQL Server Service Registration
builder.Services.AddDbContext<CSLGamingContext>(
    options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("CSLGamingConnection")));

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsAllAccessPolicy", opt =>
        opt.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod()
    );
});

RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

RegisterEndpoints();

// Configure CORRS
app.UseCors("CorsAllAccessPolicy");

app.Run();

void RegisterServices()
{
    ConfigureAutoMapper(builder.Services);
    builder.Services.AddScoped<IDbService, ProductDbService>();
}

void RegisterEndpoints()
{
    app.AddEndpoint<Product, ProductPostDTO, ProductPutDTO, ProductGetDTO>();
    app.AddEndpoint<Genere, GenerePostDTO, GenerePutDTO, GenereGetDTO>();
    app.AddEndpoint<AgeRestriction, AgeRestrictionPostDTO, AgeRestrictionPutDTO, AgeRestrictionGetDTO>();
    app.AddEndpoint<CategoryProduct, ProductCategoryPostDTO, ProductCategoryDeleteDTO>();
    app.AddEndpoint<GenereProduct, ProductGenerePostDTO, ProductGenereDeleteDTO>();
    
    
    app.MapGet($"/api/productsbycategory/" + "{categoryId}", async (IDbService db, int categoryId) =>
    {
        try
        {
            return Results.Ok(await ((ProductDbService)db).GetProductsByCategoryAsync(categoryId));
        }
        catch
        {
        }

        return Results.BadRequest($"Couldn't get the requested products of type {typeof(Product).Name}.");
    });

    app.MapGet($"/api/products/toprated/" + "{numberOfProducts}", async (IDbService db, int numberOfProducts) =>
    {
        try
        {
            return Results.Ok(await ((ProductDbService)db).GetTopRatedAsync(numberOfProducts));
        }
        catch
        {
        }

        return Results.BadRequest($"Couldn't retrieve top rated products from database.");
    });
}

void ConfigureAutoMapper(IServiceCollection services)
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Product, ProductPostDTO>().ReverseMap();
        cfg.CreateMap<Product, ProductPutDTO>().ReverseMap();
        cfg.CreateMap<Product, ProductGetDTO>().ReverseMap();
        cfg.CreateMap<Genere, GenerePostDTO>().ReverseMap();
        cfg.CreateMap<Genere, GenerePutDTO>().ReverseMap();
        cfg.CreateMap<Genere, GenereGetDTO>().ReverseMap();
        cfg.CreateMap<Genere, GenereSmallGetDTO>().ReverseMap();
        cfg.CreateMap<AgeRestriction, AgeRestrictionPostDTO>().ReverseMap();
        cfg.CreateMap<AgeRestriction, AgeRestrictionPutDTO>().ReverseMap();
        cfg.CreateMap<AgeRestriction, AgeRestrictionGetDTO>().ReverseMap();
        cfg.CreateMap<CategoryProduct, ProductCategoryPostDTO>().ReverseMap();
        cfg.CreateMap<CategoryProduct, ProductCategoryDeleteDTO>().ReverseMap();
        cfg.CreateMap<GenereProduct, ProductGenerePostDTO>().ReverseMap();
        cfg.CreateMap<GenereProduct, ProductGenereDeleteDTO>().ReverseMap();
        cfg.CreateMap<Category, CategoryPostDTO>().ReverseMap();
        cfg.CreateMap<Category, CategoryPutDTO>().ReverseMap();
        cfg.CreateMap<Category, CategoryGetDTO>().ReverseMap();
        cfg.CreateMap<Category, CategorySmallGetDTO>().ReverseMap();

    });
    var mapper = config.CreateMapper();
    services.AddSingleton(mapper);
}