using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using wsRestTodoList;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// ajout du formateur newtonsoft
builder.Services.AddControllers(options =>
    {
        options.InputFormatters.Insert(0, MyJsonPatchInputFormatter.GetJsonPatchInputFormatter());
    })
    .ConfigureApiBehaviorOptions(options=>
    {
        // To preserve the default behavior, capture the original delegate to call later.
        var builtInFactory = options.InvalidModelStateResponseFactory;

        options.InvalidModelStateResponseFactory = context =>
        {
            var logger = context.HttpContext.RequestServices
                                .GetRequiredService<ILogger<Program>>();
            // ici on peut utiliser  : context.ModelState
            // pour l'erreur courante
            // Perform logging here.
            // ...

            // Invoke the default behavior, which produces a ValidationProblemDetails
            // response.
            // To produce a custom response, return a different implementation of 
            // IActionResult instead.
            return builtInFactory(context);
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "TODO LIST API",
            Version = "1.00",
            Contact = new OpenApiContact { Name = "Fred BERTON", Email = "frederic.Berton@capgemini.com" },
            Description = "exemple d'API REST avec de la documentation",
            License = new OpenApiLicense { Name = "LGPL" }
        });

        // activé la documentation via le fichier xml généré a partir des commentaires
        var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "wsRestTodoList.xml");
        c.IncludeXmlComments(filePath);
    }
) ;

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
