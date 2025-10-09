var builder = WebApplication.CreateBuilder(args);

// Aggiungi servizi per Razor Pages
builder.Services.AddRazorPages();

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