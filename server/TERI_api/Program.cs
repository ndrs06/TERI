using Microsoft.EntityFrameworkCore;
using TERI_api.Data;
using TERI_api.Service;
using TERI_api.Service.Interface.Repo;
using TERI_api.Service.Interface.Serv;
using TERI_api.Service.Repository;

var builder = WebApplication.CreateBuilder(args);

#region Add Services
builder.Services.AddControllers();

builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRecipeService, RecipeService>();
#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Add DB Context
builder.Services.AddDbContext<TERI_Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL_CONNECTION"));
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();