﻿
using ErrorHandling.Web.Services;

namespace ErrorHandling.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddTransient<SlowService>();
        
        var app = builder.Build();
        app.UseStaticFiles();
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/error/exception");
            app.UseStatusCodePagesWithRedirects("error/http/{0}");
        }
        app.MapControllers();

        app.Run();
    }
}
