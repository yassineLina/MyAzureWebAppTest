using Microsoft.EntityFrameworkCore;
using MyWebAppAzure.Data;

var builder = WebApplication.CreateBuilder(args);

// Aggiungi servizi per Razor Pages
builder.Services.AddRazorPages();

// var connection = builder.Configuration.GetConnectionString("Azconn");

// Load connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register DbContext with the connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configura la pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();  // IMPORTANTE: per file CSS/JS/immagini
app.UseRouting();
app.UseAuthorization();



// Mappa le Razor Pages
app.MapRazorPages();

app.Run();