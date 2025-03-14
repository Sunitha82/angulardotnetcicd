var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// Enable Swagger in all environments
app.UseSwagger();
app.UseSwaggerUI();

// Use CORS - moved before UseHttpsRedirection and other middleware
app.UseCors("AllowAngularApp");

// Disable HTTPS redirection for development to avoid CORS issues with redirects
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();