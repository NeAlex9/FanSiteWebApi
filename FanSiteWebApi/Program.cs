using System.Text;
using AutoMapper;
using FanSite.EntityFramework.Services.Context;
using FanSite.EntityFramework.Services.Services;
using FanSite.Services.Entities;
using FanSite.Services.Services;
using Microsoft.EntityFrameworkCore;
using FanSiteWebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddCors(options =>
        options.AddPolicy("CORSPolicy", builder =>
            builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .WithOrigins("http://localhost:3000")));

builder.Services
    .AddControllers()
    .AddJsonOptions(option => option.JsonSerializerOptions.WriteIndented = true);

var connectionStringName = "FANSITE";

var connectionString = builder
    .Configuration
    .GetConnectionString(connectionStringName);

IConfigurationSection settingsSection = builder.Configuration.GetSection("AppSettings");
AppSettings settings = settingsSection.Get<AppSettings>();
byte[] signingKey = Encoding.UTF8.GetBytes(settings.EncryptionKey);

builder.Services
    .AddAuthentication(signingKey);

builder.Services
    .Configure<AppSettings>(settingsSection)
    .AddDbContext<SiteContext>(options => options.UseSqlServer(connectionString))
    .AddScoped<IMediaService, MediaService>()
    .AddScoped<IMediaTypeService, MediaTypeService>()
    .AddScoped<IMediaSeriesService, MediaSeriesService>()
    .AddScoped<IMediaPictureService, MediaPictureService>()
    .AddScoped<ICommentService, CommentsService>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IRoleService, RoleService>()
    .AddScoped<IAuthenticationService, AuthenticationService>()
    .AddScoped<ITokenService, TokenService>()
    .AddScoped<IMapper, Mapper>(_ => new Mapper(new MapperConfiguration(config => config.AddProfile(new FanSite.EntityFramework.Services.Mapper.MapperProfile())))); ;

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseAuthentication();

app.UseHttpsRedirection();
app.UseCors("CORSPolicy");

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();