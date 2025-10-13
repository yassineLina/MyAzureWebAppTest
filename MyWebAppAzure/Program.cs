using Microsoft.EntityFrameworkCore;
using MyWebAppAzure.Data;

var builder = WebApplication.CreateBuilder(args);

// Aggiungi servizi per Razor Pages
builder.Services.AddRazorPages();

// var connection = builder.Configuration.GetConnectionString("Azconn");


// builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(connection));

// Aggiungi questo
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Azconn")));

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