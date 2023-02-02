using Microsoft.EntityFrameworkCore;
using OnlineQuiz.DAL;
using OnlineQuiz.DbContext;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
//addlogging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication("Cookie").AddCookie("Cookie", options =>
{
    options.Cookie.Name = "Cookie";
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireClaim("Admin", "True"));
});
//add session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();

builder.Services.AddSingleton<IConfiguration>(config);

builder.Services.AddDbContext<QuizDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IAccountDAL, AccountDAL>();
builder.Services.AddScoped<IQuizDAL, QuizDAL>();
builder.Services.AddScoped<IFeedbackDAL, FeedbackDAL>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    _ = app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    _ = app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//use session
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
