using CountriesWebApi.Interface;
using CountriesWebApi.Service;
using Refit;

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IApiService, ApiService>();

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddRefitClient<ICountryApi>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new Uri(configuration["ICountryApi:BaseAddress"]);
}
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
