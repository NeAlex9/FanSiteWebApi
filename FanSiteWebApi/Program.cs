using FanSiteService.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

builder.Services
    .AddControllers()
    .AddJsonOptions(option => option.JsonSerializerOptions.WriteIndented = true);

var connectionStringName = "FANSITE";

var connectionString = builder
    .Configuration
    .GetConnectionString(connectionStringName);

builder.Services
    .AddDbContext<SiteContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();