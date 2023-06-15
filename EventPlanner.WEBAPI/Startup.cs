using EventPlanner.Data;
using EventPlanner.Data.Configuration;
using EventPlanner.Data.Infrastructures;
using EventPlanner.Domain.Models;
using EventPlanner.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EventPlanner.WEBAPI
{
    public class Startup
    {
        public Startup(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();
            //Patrons
            services.AddScoped<IDatabaseFactory, DataBaseFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //injection des services spécifiques
            services.AddScoped<IServServices, ServiceServ>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IExternServices, ServExternServices>();
            services.AddScoped<IFeedbackService, FeedbackServices>();
            //Inject AppSettings
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            services.AddDbContext<AppPlanningContext>();

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppPlanningContext>();
            services.AddCors();

            //Jwt Authentication

            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;


            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero

                };
            });
            // ...
        }

        public void Configure(IApplicationBuilder app, IHostApplicationLifetime lifetime)
        {


            app.UseCors(builder =>
            builder.WithOrigins(Configuration["ApplicationSettings:Client_URL"].ToString())
            .AllowAnyHeader()
            .AllowAnyMethod());



            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            // ...
        }
    }
}
