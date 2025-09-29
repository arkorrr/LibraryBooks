using LibraryBooks;
using LibraryBooks.Models;
using LibraryBooks.Resources;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddRazorPages()
	.AddDataAnnotationsLocalization(options =>
	{
		options.DataAnnotationLocalizerProvider = (type, factory) =>
			factory.Create(typeof(ValidationMessages));
	});

builder.Services.AddSingleton<Book>();
builder.Services.AddMemoryCache();

var app = builder.Build();

var supportedCultures = new[] { new CultureInfo("en-US"), new CultureInfo("ru-RU") };

var reqLocOptions = new RequestLocalizationOptions
{
	DefaultRequestCulture = new RequestCulture("en-US"),
	SupportedCultures = supportedCultures.ToList(),
	SupportedUICultures = supportedCultures.ToList()
};

reqLocOptions.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
reqLocOptions.RequestCultureProviders.Insert(1, new CookieRequestCultureProvider());

app.UseRequestLocalization(reqLocOptions);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
