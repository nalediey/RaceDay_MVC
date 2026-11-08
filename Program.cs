using System.Net.Http.Headers;
using RaceDay_MVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Required for AuthTokenHandler to read cookies
builder.Services.AddHttpContextAccessor();

// Register a named client for your API
builder.Services.AddHttpClient("RaceDayApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7258/"); // Your API URL
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
})
.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
{
    // THIS IS IMPORTANT FOR LOCALHOST DEV (Trusting the local SSL cert)
    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
})
.AddHttpMessageHandler<AuthTokenHandler>();

// Register the AuthTokenHandler
builder.Services.AddTransient<AuthTokenHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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