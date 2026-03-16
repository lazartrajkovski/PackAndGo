using PackAndGo.Configuration;
using PackAndGo.ExternalApiServices;
using PackAndGo.ExternalApiServices.Interfaces;
using PackAndGo.Middlewares;
using PackAndGo.Repositories;
using PackAndGo.Repositories.Interfaces;
using PackAndGo.Services;
using PackAndGo.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddHttpClient<IHotelService, HotelService>();
builder.Services.AddHttpClient<IFlightService, FlightService>();
builder.Services.AddSingleton<ISearchTypeService, SearchTypeService>();
builder.Services.AddSingleton<IBookingRepository, BookingRepository>();
builder.Services.AddSingleton<IBookingService, BookingService>();
builder.Services.AddSingleton<IStatusService, CheckStatusService>();
builder.Services.AddSingleton<HotelOnlyService>();
builder.Services.AddSingleton<HotelAndFlightService>();
builder.Services.AddSingleton<LastMinuteHotelService>();
builder.Services.Configure<ExternalApiSettings>(
    builder.Configuration.GetSection("ExternalApiUrls"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
