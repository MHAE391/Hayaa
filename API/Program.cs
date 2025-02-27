using Business.Repositories.Agencies;
using Database;
using Microsoft.EntityFrameworkCore;
using UseCases.AgencyUseCases.Create;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(option => 
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Database") , b => b.MigrationsAssembly("API"))
    .UseLazyLoadingProxies();
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateAgencyCommand).Assembly));

builder.Services.AddScoped<IAgencyRepository , AgencyRepository>();
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
