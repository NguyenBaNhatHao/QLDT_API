using QLDT_API.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using QLDT_API.Models;
using Microsoft.Net.Http.Headers;
using System;

Console.WriteLine("CurrentDirectory in Main: {0}", System.IO.Directory.GetCurrentDirectory());
var builder = WebApplication.CreateBuilder(args);
string sConnection = builder.Configuration.GetConnectionString("VidoWebConnection");
// if(sConnection==null || string.IsNullOrEmpty(sConnection))
// {
//     sConnection = "Server=zalovido.pmsa.com.vn,2020;Database=Vido;User Id=vido01;Password=Vido@01";
// }
Console.WriteLine("TestConnection" + sConnection);
builder.Services.AddDbContext<VidoWebDbContext>(opt => opt.UseSqlServer(sConnection));
builder.Services.AddControllers();
builder.Services.AddHttpClient();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "VidoWeb", Version = "v1"});
});
builder.Services.AddHttpClient("VidoWeb", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://admintt.viendong.edu.vn");
    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.UserAgent, "https://admintt.viendong.edu.vn");
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZaloVido v1"));
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapDefaultControllerRoute();

app.Run();