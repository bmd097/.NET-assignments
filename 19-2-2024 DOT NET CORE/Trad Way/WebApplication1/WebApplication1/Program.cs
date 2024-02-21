using WebApplication1.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<FishCatcherUtil>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

// Instead of this
/*app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
});*/
// use
app.MapControllers();
app.MapRazorPages();

app.UseRouting();

// app.UseAuthorization();


app.MapGet("/fish", () => {
    var fishCather = app.Services.GetService<FishCatcherUtil>();
    fishCather?.CatchFish();
    return new {
        Name = "Mohan"
    };
});

app.Run();
