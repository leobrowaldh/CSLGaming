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
    app.AddEndpoint<Product, ProductPostDTO , ProductPutDTO, ProductGetDTO>();
   
}
