using ClaimFlow.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddOpenApi();

builder.Services.AddSingleton<ClaimService>();
builder.Services.AddSingleton<ClaimStatusService>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Map controller routes
app.MapControllers();

// Health check endpoint
app.MapGet("/api/health", () =>
{
    return Results.Ok(new
    {
        Status = "Healthy",
        Application = "ClaimFlow API",
        Timestamp = DateTime.UtcNow
    });
})
.WithName("GetHealth");

app.Run();
