using Microsoft.OpenApi.Models;
using PostBook.Installers;
using PostBook.Options;
var builder = WebApplication.CreateBuilder(args);
var installers = typeof(Program).Assembly.ExportedTypes.Where(x =>
typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();
installers.ForEach(x => x.InstallService(builder.Services, builder.Configuration));
// Add services to the container.
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    var swaggerOptions = new SwaggerOptions();
    app.Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
    app.UseSwagger(option =>
    {
        option.RouteTemplate = swaggerOptions.JsonRoute;
    });
    app.UseSwaggerUI(option =>
    {
        option.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description);
    });
}
//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
