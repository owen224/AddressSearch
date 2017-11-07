using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace AddressSearch.Infrastructure
{
    public static class Authentication
    {
        private static readonly SymmetricSecurityKey SigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("secretkey_secretkey123!"));

        private static readonly TokenValidationParameters TokenValidationParameters = new TokenValidationParameters
        {
            // The signing key must match!
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SigningKey,
            // Validate the JWT Issuer (iss) claim
            ValidateIssuer = true,
            ValidIssuer = "DemoIssuer",
            // Validate the JWT Audience (aud) claim
            ValidateAudience = true,
            ValidAudience = "DemoAudience",
            // Validate the token expiry
            ValidateLifetime = true,
            // If you want to allow a certain amount of clock drift, set that here:
            ClockSkew = TimeSpan.Zero
        };

        public static void ConfigureAuth(IServiceCollection services)
        {
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options => { options.TokenValidationParameters = TokenValidationParameters; });
        }
    }
}
