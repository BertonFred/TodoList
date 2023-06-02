using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using wsRestTodoList;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using wsRestTodoList.HealthCheck;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Ajouter un point de HealthChecks pour faciliter la surveillance de l'application par les OPS
// ici on fait un appel àServiceOneCheck en passant la valeur de retour du healthCheck (pour faire simple)
builder.Services.AddHealthChecks()
                .AddTypeActivatedCheck<ServiceOneHealthCheck>("RestTodoListHealthCheckOne", args: new object[] { HealthStatus.Healthy })
                .AddTypeActivatedCheck<ServiceOneHealthCheck>("RestTodoListHealthCheckTwo", args: new object[] { HealthStatus.Healthy })
                .AddCheck("Lambda Check",() => HealthCheckResult.Healthy("Lambda Check."));
//builder.Services.AddHealthChecksUI();
builder.Services.AddHealthChecksUI(options =>
{
    options.SetEvaluationTimeInSeconds(5);
    options.MaximumHistoryEntriesPerEndpoint(10);
    //options.AddHealthCheckEndpoint("API com Health Checks", "/healthz");
    //options.AddHealthCheckEndpoint("API2 com Health Checks", "/healthz");
})
.AddInMemoryStorage(); 

// Add services to the container.
// ajout du formateur newtonsoft pour la gestion de l'API PATCH
builder.Services.AddControllers();
builder.Services.AddControllers(options =>
    {
        options.InputFormatters.Insert(0, MyJsonPatchInputFormatter.GetJsonPatchInputFormatter());
    })
    .ConfigureApiBehaviorOptions(options =>
    {
        // To preserve the default behavior, capture the original delegate to call later.
        var builtInFactory = options.InvalidModelStateResponseFactory;

        options.InvalidModelStateResponseFactory = context =>
        {
            var logger = context.HttpContext.RequestServices
                                .GetRequiredService<ILogger<Program>>();

            // ici on peut utiliser : context.ModelState
            // pour l'erreur courante
            foreach (var modelState in context.ModelState.Values)
                foreach (ModelError error in modelState.Errors)
                    Debug.WriteLine($"LOG ERREUR ModelSate : {error.ErrorMessage}");


            // Invoke the default behavior, which produces a ValidationProblemDetails
            // response.
            return builtInFactory(context);
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Versionning
// https://medium.com/@ravindradevrani/api-versioning-in-net-core-net-7-2eab5142f5a0
// https://github.com/dotnet/aspnet-api-versioning/wiki/API-Versioning-Options
// https://github.com/dotnet/aspnet-api-versioning/wiki
builder.Services.AddApiVersioning(optVersion =>
{
    optVersion.DefaultApiVersion = new ApiVersion(1, 1);
    optVersion.ReportApiVersions = true;
});

builder.Services.AddSwaggerGen(c =>
    {
        //c.SwaggerDoc("v1", new OpenApiInfo
        //{
        //    Title = "TODO LIST API",
        //    Version = "9.99",
        //    Contact = new OpenApiContact { Name = "Fred BERTON", Email = "frederic.Berton@capgemini.com" },
        //    Description = "exemple d'API REST avec de la documentation",
        //    License = new OpenApiLicense { Name = "LGPL" }
        //});

        var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "wsRestTodoList.xml");
        c.IncludeXmlComments(filePath);
        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    }
) ;

var app = builder.Build();
app.Logger.LogInformation("Démarrage du Web services");

// Configure the HTTP request pipeline.
// Dans l'exemple ici nous activons le service de docuemntation Swagger uniquement si l'environnement
// d'execution est un environnement de developpement
// Ce qui n'est pas toujours une bonne idée. Regulierment on active Swagger dans tous les environnement Dev ou pas.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ajouter le point de HealthCheck pour la supervision application du SI.
app.MapHealthChecks("/healthz");
app.UseHealthChecksUI();

app.UseAuthorization();
app.MapControllers();
app.Run();
