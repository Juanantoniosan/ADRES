using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System.Configuration;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddMvc().AddMvcOptions(options =>
    {
        options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(_ => "El valor '{0}' no es válido.");
    });

builder.Services.AddRazorPages()
    .AddMvcOptions(options =>
    {
        options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor((x) =>
        {
            return "Value Can not be null....";
        });
        options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(_ => "El valor '{0}' no es válido.");
        options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(_ => "El campo {0} debe ser un número.");
        options.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(_ => "No se proporcionó un valor para la propiedad '{0}'.");
        options.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(() => "Se requiere un valor.");
        options.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor(_ => "El valor proporcionado no es válido para {0}.");
        options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(_ => "El valor debe ser un número válido.");
    });

builder.Services.AddSingleton
    <IValidationAttributeAdapterProvider, PruebaAdres.Modelo.CustomValidationAttributeAdapterProvider>();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { new CultureInfo("es") };
    options.DefaultRequestCulture = new RequestCulture("es", "es");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

builder.Services.AddDbContext<PruebaAdres.Modelo.AdquisicionesContext>(options =>
                options.UseSqlite());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
