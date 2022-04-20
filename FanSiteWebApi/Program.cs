using AutoMapper;
using FanSite.EntityFramework.Services.Services;
using FanSite.Services.Services;
using FanSite.Services.Services.MediaSelector;
using FanSiteService.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddCors(options => 
        options.AddPolicy("CORSPolicy", builder => 
            builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins("http://localhost:3000")));

builder.Services
    .AddControllers()
    .AddJsonOptions(option => option.JsonSerializerOptions.WriteIndented = true);

var connectionStringName = "FANSITE";

var connectionString = builder
    .Configuration
    .GetConnectionString(connectionStringName);

builder.Services
    .AddDbContext<SiteContext>(options => options.UseSqlServer(connectionString))
    .AddScoped<IMediaService, MediaService>()
    .AddScoped<IMediaTypeService, MediaTypeService>()
    .AddScoped<IMediaSelectorService, MediaSelectorService>()
    .AddScoped<IMediaSeriesService, MediaSeriesService>()
    .AddScoped<IMapper, Mapper>(_ => new Mapper(new MapperConfiguration(config => config.AddProfile(new FanSite.EntityFramework.Services.Mapper.MapperProfile())))); ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseCors("CORSPolicy");

app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();