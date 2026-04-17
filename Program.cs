using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ITAssetDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<LocationRepository>(); // ADDS THIS LOCATION REPOSITORY TO THE DEPENDENCY INJECTION CONTAINER SO WE CAN USE IT EVERYWHERE IT'S NEEDED
builder.Services.AddScoped<EquipmentRepository>(); // ADDS THIS EQUIPMENT REPOSITORY TO THE DEPENDENCY INJECTION CONTAINER SO WE CAN USE IT EVERYWHERE IT'S NEEDED

// Exception Handler (before builder.Build() is called)
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
    {
        // Don't automatically validate request bodies, as we will do our own validation.
        options.SuppressModelStateInvalidFilter = true;
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
