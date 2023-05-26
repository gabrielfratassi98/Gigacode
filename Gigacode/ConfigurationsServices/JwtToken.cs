using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Gigacode.Services.ConfigurationsServices
{
    public static class JwtToken
    {
        public static void JwtTokenConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            var key = configuration.GetValue<string>("ApiKey");
            var keyEncoding = Encoding.ASCII.GetBytes(key);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    IssuerSigningKey = new SymmetricSecurityKey(keyEncoding),
                    ValidIssuer = "Gigacode",
                    ValidAudience = "gigacode.com.br"
                };
            });
        }
    }
}