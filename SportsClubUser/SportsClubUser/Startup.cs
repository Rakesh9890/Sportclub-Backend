/*using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SportClubProject.Repository;
using SportClubProject.UserRepository;

namespace SportsClubUser
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
            services.AddScoped<ISportsRepo, SportsRepoImpl>();
            services.AddScoped<ICourtsRepo, CourtsRepoImplcs>();
            services.AddScoped<ISlotsRepo, SlotsRepoImpl>();
            services.AddScoped<IBookingRepo, BookingRepompl>();
            services.AddScoped<ICartsRepo, CartsRepoImpl>();
            services.AddScoped<ICouponsRepo, CouponsRepoImpl>();
            services.AddScoped<ISlotsRepo, SlotsRepoImpl>();
            services.AddScoped<IPaymentRepo, PaymentRepoImpl>();
            services.AddScoped<IUserRepository, UserRepositoryImpl>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Configuration Service", Version = "v1" });
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
*/