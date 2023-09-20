using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using paAjmoPokusat.DataAccess.Data;
using paAjmoPokusat.DataAccess.Repository;
using paAjmoPokusat.DataAccess.Repository.IRepository;
using paAjmoPokusat.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
//builder.Services.AddScoped<IIncidentTypeRepository, IncidentTypeRepository>(); zamijenimo sa ovim dole
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<IEmailSender, EmailSender>();

var emailConfig = builder.Configuration
        .GetSection("EmailConfiguration")
        .Get<paAjmoPokusat.EmailService.EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddAuthentication().AddGoogleOpenIdConnect(options =>
{
    options.ClientId = "689151936674-oik1sbmianfrhrq22o5l24jv48f174f9.apps.googleusercontent.com";
    options.ClientSecret = "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";
    options.CallbackPath = "/";
});
builder.Services.AddControllers();

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

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
