using Microsoft.EntityFrameworkCore;
using Stores.Client.Pages;
using Stores.Components;
using Stores.Data;
using Stores.Services.CategoryService;
using Stores.Services.EmployeService;
using Stores.Services.HumanService;
using Stores.Services.ProductService;
using Stores.Services.StoreService;
using Stores.Services.SubCategoryService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContext<DataContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
    ServiceLifetime.Scoped);

//builder.Services.AddDbContext<CategoryDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
//    ServiceLifetime.Scoped);
//builder.Services.AddDbContext<EmployeDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
//    ServiceLifetime.Scoped);
//builder.Services.AddDbContext<HumanDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
//    ServiceLifetime.Scoped);
//builder.Services.AddDbContext<ProductDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
//    ServiceLifetime.Scoped);
//builder.Services.AddDbContext<StoreDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
//    ServiceLifetime.Scoped);
//builder.Services.AddDbContext<SubCategoryDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
//    ServiceLifetime.Scoped);

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IEmployeService, EmployeService>();
builder.Services.AddScoped<IHumanService, HumanService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();

builder.Services.AddServerSideBlazor(options => options.DetailedErrors = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

app.Run();
