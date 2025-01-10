using pokedex.Services;
using pokedex.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Configure MongoDB settings
builder.Services.Configure<PokedexDatabaseSettings>(
    builder.Configuration.GetSection("PokedexDatabaseSettings"));

// Register services
builder.Services.AddScoped<IPokemonService, PokemonService>(); // Scoped service for PokemonService

// Add authorization service
builder.Services.AddAuthorization();

// Add controllers service
builder.Services.AddControllers();

// Set up Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Enable Swagger UI in development environment
}

// Enable Authorization middleware
app.UseAuthorization();

// Map controllers to the app
app.MapControllers();

// Run the application
app.Run();
