using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Eduard_Sergiu.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});


// Add services to the container.
builder.Services.AddRazorPages(options=>
{
    options.Conventions.AuthorizeFolder("/Breakfasts");
    options.Conventions.AllowAnonymousToPage("/Breakfasts/Index");
    options.Conventions.AllowAnonymousToPage("/Breakfasts/Details");
    options.Conventions.AuthorizeFolder("/Customers", "AdminPolicy");
}
);
builder.Services.AddDbContext<Eduard_SergiuContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Eduard_SergiuContext") ?? throw new InvalidOperationException("Connection string 'Eduard_SergiuContext' not found.")));

builder.Services.AddDbContext<RestaurantIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("Eduard_SergiuContext") ?? throw new InvalidOperationException("Connectionstring 'Eduard_SergiuContext' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<RestaurantIdentityContext>();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<RestaurantIdentityContext>();

var app = builder.Build();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
