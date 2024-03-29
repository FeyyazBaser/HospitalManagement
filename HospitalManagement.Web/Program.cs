using HospitalManagement.Web.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>

{
    options.IdleTimeout = TimeSpan.FromSeconds(30);
});

builder.Services.AddHttpClient<ProductApiService>(opt =>
{

    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);

});
builder.Services.AddHttpClient<WarehouseApiService>(opt =>
{

    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);

});
builder.Services.AddHttpClient<BuildingApiService>(opt =>
{

    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);

});
builder.Services.AddHttpClient<RoomApiService>(opt =>
{

    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);

});
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
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
