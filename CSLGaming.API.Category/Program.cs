using CSLGaming.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SQL Server Service Registration
builder.Services.AddDbContext<CSLGamingContext>( // Lägger till Contexten!
    options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("CSLGamingConnection"))); // Läser ifrån namnet vi har valt i app-settings. De matchar inte blir förvirrad (Ta bort sen*)

//CORS Access policy
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsAllAccessPolicy", opt =>
        opt.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod()
    );
});

RegisterServices();

var app = builder.Build(); // Ovanför här registrerar vi Contexten vi vill använda! (Ta bort sen)
// Pipeline är kopplingar som skickar data, fram och tillbaka, Det är viktigt med ordningarna, så att dina anrop körs vid rätt punkt.

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


void RegisterServices()
{
    ConfigureAutoMapper();
    builder.Services.AddScoped<IDbService, CategoryDbService>();
}

void ConfigureAutoMapper()
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Category, CategoryPostDTO>().ReverseMap();
        cfg.CreateMap<Category, CategoryPutDTO>().ReverseMap();
        cfg.CreateMap<Category, CategoryGetDTO>().ReverseMap();
        cfg.CreateMap<Category, CategorySmallGetDTO>().ReverseMap();

    });

    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}
