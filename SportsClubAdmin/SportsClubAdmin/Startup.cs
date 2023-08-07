using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using SportClubProject.AdminRepository;
using SportClubProject.Repository;
using SportClubProject.Services;
using SportsClubAdmin.AdminRepository;
using SportsProject.Services;
using SportsTime365.Authentication.Services;
using System.Text;
using Twilio.Clients;

namespace SportsClubAdmin
{
    public class Startup
    {

        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SportsDbContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            });


            services.AddLogging(configure =>
            {
                configure.AddConsole(); 
                
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            services.AddControllers();
            services.AddScoped<UserService, UserService>();
            services.AddScoped<IUserRepository,UserRepositoryImpl>();

            //adding sports repository 
            services.AddScoped<ISportsRepository, SportRepositoryImpl>();

            services.AddScoped<ICourtsRepository, CourtsRepositoryImpl>();

            //adding stadium repository
            services.AddScoped<IStadiumsRepository, StadiumRepositoryImpl>();

            //adding slots repository
            services.AddScoped<ISlotsRepository, SlotsRepositoryImpl>();

            //adding dashboardrepository
            services.AddScoped<IDashBoardRepo,DashBoardRepoImpl>();

            //services.AddScoped<UserService, UserService>();
            
            services.AddScoped<ITokenService, JwtTokenService>();
            services.AddHttpClient<ITwilioRestClient, Twiloclient>();


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                ValidateIssuer = false,
                ValidateAudience = false,
                RoleClaimType = "role"
            };
        });


            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy =>
                    policy.RequireRole("admin")); // Define a policy that requires the "admin" role
            });


            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Configuration Service", Version = "v1" });
            });


            // Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File("Log/log.txt", rollingInterval: RollingInterval.Minute)
                .CreateLogger();

            // Add logging with Serilog
            services.AddLogging(builder =>
            {
                builder.ClearProviders(); // Optional, if you want to remove any built-in log providers
                builder.AddSerilog(dispose: true);
            });


        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
            }

            //app.UseSession();
            //app.Use(async (context, next) =>
            //{
            //    var token = context.Session.GetString("Token");
            //    if (!string.IsNullOrEmpty(token))
            //    {
            //        context.Request.Headers.Add("Authorization", "Bearer " + token);
            //    }
            //    await next();
            //});
            //app.UseStaticFiles();
            //app.UseRouting();
            //app.UseAuthentication();

            /* // Configure Serilog
             Log.Logger = new LoggerConfiguration()
                 .MinimumLevel.Information()
                 .WriteTo.File("Log/log.txt", rollingInterval: RollingInterval.Minute)
                 .CreateLogger();

             // Override the built-in loggers with Serilog
             app.UseSerilogRequestLogging();*/

            app.UseSerilogRequestLogging();
            app.UseRouting();
            app.UseCors("AllowAllOrigins");

            // Enable authentication and authorization
            app.UseAuthentication();
            app.UseAuthorization();

           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
                options.SwaggerEndpoint("/swagger/userData/swagger.json", "User Data");
                options.RoutePrefix = "swagger";
            });
        }
    }
}
