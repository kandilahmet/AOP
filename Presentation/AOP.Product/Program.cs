using AOP.Persistence;
using AOP.Application;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AOP.Application.Features.Commands.Requests;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();


app.MapPost("/AddProduct", async (AddProductCommandRequest request, IMediator mediatR) =>
{ 
    await mediatR.Send(request);
});


app.MapPost("/AddCategory", async (AddCategoryCommandRequest request , IMediator mediatR) =>
{ 
    await mediatR.Send(request);
});


app.Run();

