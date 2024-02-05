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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Configure CORRS
app.UseCors("CorsAllAccessPolicy");

app.Run();

void RegisterServices(IServiceCollection services)
{
    ConfigureAutoMapper(builder.Services);
    services.AddScoped<IDbService, ProductDbService>();
}

void RegisterEndpoints(WebApplication app)
{
    app.AddEndpoint<Product, ProductPostDTO, ProductPutDTO, ProductGetDTO>();
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
        cfg.CreateMap<AgeRestriction, AgeRestrictionPostDTO>().ReverseMap();
        cfg.CreateMap<AgeRestriction, AgeRestrictionPutDTO>().ReverseMap();
        cfg.CreateMap<AgeRestriction, AgeRestrictionGetDTO>().ReverseMap();
        cfg.CreateMap<CategoryProduct, ProductCategoryPostDTO>().ReverseMap();
        cfg.CreateMap<CategoryProduct, ProductCategoryDeleteDTO>().ReverseMap();
        cfg.CreateMap<GenereProduct, ProductGenerePostDTO>().ReverseMap();
        cfg.CreateMap<GenereProduct, ProductGenereDeleteDTO>().ReverseMap();
        cfg.CreateMap<AgeRestrictionProduct, ProductAgeRestrictionPostDTO>().ReverseMap();
        cfg.CreateMap<AgeRestrictionProduct, ProductAgeRestrictionDeleteDTO>().ReverseMap();
    });
    var mapper = config.CreateMapper();
    services.AddSingleton(mapper);
}