using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SQL Server Service Registration
builder.Services.AddDbContext<CSLGamingContext>( // L�gger till Contexten!
    options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("CSLGamingConnection"))); // L�ser ifr�n namnet vi har valt i app-settings. De matchar inte blir f�rvirrad (Ta bort sen*)

//CORS Access policy
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsAllAccessPolicy", opt =>
        opt.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod()
    );
});

var app = builder.Build(); // Ovanf�r h�r registrerar vi Contexten vi vill anv�nda! (Ta bort sen)
// Pipeline �r kopplingar som skickar data, fram och tillbaka, Det �r viktigt med ordningarna, s� att dina anrop k�rs vid r�tt punkt.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

RegisterEndpoints();

app.Run();

void RegisterEndpoints()
{
    app.AddEndpoint<Category, CategoryPostDTO, CategoryPutDTO, CategoryGetDTO>();
   
}

void ConfigureAutoMapper()
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Product, ProductPostDTO>().ReverseMap();
        cfg.CreateMap<Product, ProductPutDTO>().ReverseMap();
        cfg.CreateMap<Product, ProductGetDTO>().ReverseMap();
        cfg.CreateMap<Product, ProductSmallGetDTO>().ReverseMap();
    });

    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}
