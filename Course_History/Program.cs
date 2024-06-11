using Course_History.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//ConnectDb
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectDB"));
});

builder.Services.AddHttpContextAccessor();
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.IsEssential = true;
});
/*builder.Services.AddSingleton<IAuthService, AuthService>();*/
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseSession();
app.Use(async (context, next) =>
{
    var session = context.Session;
    var username = session.GetString("Username");
    var role = session.GetString("Role");

    if (username == null && !context.Request.Path.Value.ToLower().Contains("/login"))
    {
        context.Response.Redirect("/Login");
        return;
    }
	if (username != null && context.Request.Path.Value.ToLower().Contains("/login"))
	{
        if (role.Equals("admin")) {
			context.Response.Redirect("/Admin");
            return;
		}
		
		context.Response.Redirect("/");
		return;
	}
	

	if (context.Request.Path.Value.ToLower().Contains("/admin") && role != "admin")
    {
        context.Response.StatusCode = 403; // Forbidden
        await context.Response.WriteAsync("Forbidden");
        return;
    }
    else
    {

    }

    await next.Invoke();
});




app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
	name: "Areas",
	pattern: "{area:exists}/{controller=Product}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");


/*app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Product}/{action=Index}/{id?}");*/

app.Run();

