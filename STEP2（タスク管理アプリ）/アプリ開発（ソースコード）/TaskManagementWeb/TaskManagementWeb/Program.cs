using WebTaskManagement.Repositories;
using WebTaskManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// TaskRepository ‚Ì“o˜^iÚ‘±•¶Žš—ñ•t‚«j© ‚±‚ê‚¾‚¯‚ÅOKI
builder.Services.AddScoped(sp =>
    new TaskRepository(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<TaskService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
