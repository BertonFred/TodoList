using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;

namespace wsRestTodoList;

/// <summary>
/// Help pour mettre en place le formatteur JSon Patch de newtownsoft
/// car le formateur MS ne prend pas en charge JsonPatchDocument
/// selon la documentation MS : https://learn.microsoft.com/fr-fr/aspnet/core/web-api/jsonpatch?view=aspnetcore-6.0#add-support-for-json-patch-when-using-systemtextjson
/// </summary>
public static class MyJsonPatchInputFormatter
{
    public static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
    {
        var builder = new ServiceCollection()
            .AddLogging()
            .AddMvc()
            .AddNewtonsoftJson()
            .Services.BuildServiceProvider();

        return builder
            .GetRequiredService<IOptions<MvcOptions>>()
            .Value
            .InputFormatters
            .OfType<NewtonsoftJsonPatchInputFormatter>()
            .First();
    }
}