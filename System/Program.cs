using Microsoft.EntityFrameworkCore;
using RegisterSystem.Domain.IRepos;
using RegisterSystem.Domain.Party;
using RegisterSystem.Infra;
using RegisterSystem.Infra.Initializers;
using RegisterSystem.Infra.Party;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddDbContext<RegisterDb>(o =>
    o.UseSqlServer(connectionString));



builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddRazorPages();

builder.Services.AddTransient<IEventsRepo, EventsRepo>();
builder.Services.AddTransient<ICompaniesRepo, CompaniesRepo>();
builder.Services.AddTransient<ICiviliansRepo, CiviliansRepo>();
builder.Services.AddTransient<IEventsCiviliansRepo, EventsCiviliansRepo>();
builder.Services.AddTransient<IEventsCompaniesRepo, EventsCompaniesRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
using (var scope = app.Services.CreateScope())
{
    GetRepo.SetService(app.Services);
    var db = scope.ServiceProvider.GetService<RegisterDb>();
    _ = (db?.Database?.EnsureCreated());
    RegisterDbInitializer.Init(db);
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
