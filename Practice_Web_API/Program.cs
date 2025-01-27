using Practice_Web_API.BAL;
using Practice_Web_API.DATA;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserRepository,UserRepository>();
builder.Services.AddScoped<User_BALbase>();
builder.Services.AddScoped<CountryRepository,CountryRepository>();
builder.Services.AddScoped<Country_BALbase>();
builder.Services.AddScoped<StateRepository,StateRepository>();
builder.Services.AddScoped<State_BALbase>();
builder.Services.AddScoped<DistrictRepository,DistrictRepository>();
builder.Services.AddScoped<District_BALbase>();
builder.Services.AddScoped<TalukaRepository,TalukaRepository>();
builder.Services.AddScoped<Taluka_BALbase>();
builder.Services.AddScoped<CityRepository,CityRepository>();
builder.Services.AddScoped<City_BALbase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
