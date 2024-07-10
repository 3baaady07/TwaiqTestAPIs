using Asp.Versioning.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerUI;
using TwaiqTestAPIs.Data;
using TwaiqTestAPIs.OpstionsSetup;
using TwaiqTestAPIs.Repositories;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICityInfoRepository, CityInfoRepository>();
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.ConfigureOptions<WeatherHttpClientOptionsSetup>();
builder.Services.AddHttpClient("weather");

builder.Services.ConfigureOptions<ApiVersioningOptionsSetup>();
builder.Services.ConfigureOptions<ApiExplorerOptionsSetup>();
builder.Services.AddApiVersioning().AddMvc().AddApiExplorer();

builder.Services.ConfigureOptions<MvcOptionsSetup>();

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureOptions<SwaggerGenOptionsSetup>();
builder.Services.AddSwaggerGen();


//builder.Services.ConfigureOptions<SwaggerUIOptionsSetup>();
WebApplication app = builder.Build();
app.SeedData();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        IReadOnlyList<ApiVersionDescription> descriptions = app.DescribeApiVersions();
        foreach (ApiVersionDescription description in descriptions)
        {
            options
                .SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant()
                );
        }
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
