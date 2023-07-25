using FluentValidation.AspNetCore;
using TWYLisans.Application.Validators.Customers;
using TWYLisans.Application.Validators.Licences;
using TWYLisans.Application.Validators.Products;
using TWYLisans.Persistence;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPersistenceServices();

builder.Services.AddControllersWithViews()
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateCustomerValidator>())
    .AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .AddFluentValidation(c=> c.RegisterValidatorsFromAssemblyContaining<CreateLicenceValidator>());


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Index");
   
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
