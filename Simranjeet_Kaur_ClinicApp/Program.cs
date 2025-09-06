using Microsoft.EntityFrameworkCore;
using Simranjeet_Kaur_ClinicApp.Models;
using Simranjeet_Kaur_ClinicApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();


builder.Services.AddDbContext<ClinicDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ClinicDBConnection")));


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
    pattern: "{controller=Patients}/{action=Index}/{id?}");

app.Run();
