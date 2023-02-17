using DeployEntityFramework.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.WebSockets;

var builder = WebApplication.CreateBuilder(args);

// add services to the container
builder.Services.AddControllersWithViews(); // enable mvc 
builder.Services.AddDbContext<ProjectContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//------------------------------

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();      // copied from mcv template
app.UseStaticFiles();           // added from pluralsight video
app.UseRouting();               // adds route matching to the middleware pipeline

app.UseEndpoints(endpoints =>   // adds endpoint execution to the middleware pipeline.
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id:int?}");
});

//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    //var context = services.GetRequiredService<ProjectContext>();    
//    //context.Database.EnsureCreated();

//    // call method to create lookup and sample data 
//    SeedData.Initialize(services);
//}

app.Run();
