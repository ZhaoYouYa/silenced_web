
using Sys_Pgsql;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

PgContext pgsql = new ("Host=212.129.223.183;Port=5433;Username=postgres;Password=Yuanmo520...;Database=Silenced2;");

builder.Services.AddSingleton(pgsql);

//builder.Services.AddDbContext<PgContext>(options =>
//{
//	options.UseNpgsql("Host=212.129.223.183;Port=5433;Username=postgres;Password=Yuanmo520...;Database=Silenced2;");
//});

builder.Services.AddStackExchangeRedisCache(
	options =>
	{
		options.Configuration = "212.129.223.183:6370";
		options.InstanceName = "SilencedSession";
	}
	);

builder.Services.AddSession(options => {
	options.Cookie.Name = ".Silenced.Session";
	options.IdleTimeout = TimeSpan.FromMinutes(60 * 24);
	options.Cookie.IsEssential = true;
});



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();
app.UseSession();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
/// <summary>
/// Global Error Handle
/// </summary>
app.UseExceptionHandler(options =>
{
	options.Run(async context =>
	{
		context.Response.ContentType = "application/json";
		context.Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
		var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();
		if (null != exceptionObject)
		{
			var resp = "{\"isSuccess\":false,\"message\":" + $"\"{exceptionObject.Error.Message}\"" + "}";
			await context.Response.WriteAsync(resp).ConfigureAwait(false);
		}
	});

});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
