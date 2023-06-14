using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IMyService, MyService>();
builder.Services.AddAuthentication().AddCookie(options =>
{
	options.Cookie.HttpOnly = true;
	options.SlidingExpiration = true;
	options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
	options.Cookie.SameSite = SameSiteMode.Strict;
	options.ExpireTimeSpan = TimeSpan.FromHours(1);
});
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapDefaultControllerRoute();
app.Run();
