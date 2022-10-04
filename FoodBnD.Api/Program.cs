using FoodBnD.Api.Common.Errors;
using FoodBnD.Application;
using FoodBnD.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;


var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
        
    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, FoodBnDProblemDetailsFactory>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


