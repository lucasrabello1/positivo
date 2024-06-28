using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Text;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        ConfigureServices(builder.Services, builder.Configuration);

        var app = builder.Build();


        ConfigureMiddleware(app, applicationBuilder11);

        app.Run();

        void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            var jwtSettings = configuration.GetSection("Jwt").Get<JwtSettings>();
            services.AddSingleton(jwtSettings);

            var authenticationBuilder = services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
                };
            });

            services.AddAuthorization();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            services.AddSingleton<ServicoService>();
        }

        void ConfigureMiddleware(WebApplication app, IApplicationBuilder applicationBuilder)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            IApplicationBuilder applicationBuilder1 = app.UseAuthorization();
            IApplicationBuilder applicationBuilder11 = applicationBuilder1;
            app.MapControllers();
        }
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}