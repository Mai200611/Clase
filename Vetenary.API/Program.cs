using Microsoft.EntityFrameworkCore;
using Veterinary.API.Data;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Datacontext>(x => x.UseSqlServer("name=DefaultConnection"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())

{

    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
