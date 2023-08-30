using LaFermeWeb.Helper;

var builder = WebApplication.CreateBuilder(args);

{
	var services = builder.Services;
	var env = builder.Environment;

	// Add services to the container.
	services.AddRazorPages();
	services.AddDbContext<DataContext>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
