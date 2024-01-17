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
    app.AddEndpoint<Product, ProductPostDTO , ProductPutDTO, ProductGetDTO>();
   
}
