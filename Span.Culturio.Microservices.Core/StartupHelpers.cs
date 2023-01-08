using System;
using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Span.Culturio.Microservices.Core.Helpers;
using Swashbuckle.AspNetCore.Filters;
using Span.Culturio.Microservices.Core.Models;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Span.Culturio.Microservices.Core
{
	public static class StartupHelpers
	{
		public static void RegisterApiServices(this IServiceCollection services, string jwtToken)
		{
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\"",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<UserValidator>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtToken)),
                        ValidateAudience = false,
                        ValidateIssuer = false

                    };
                });




        }


        public static void RegisterSerilog(this WebApplicationBuilder builder)
        {
            //var logger = new LoggerConfiguration();
            //logging
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .Enrich.WithCorrelationIdHeader()
                .CreateLogger();

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);


        }


        public static void RegisterHeaderPropagation(this IServiceCollection services)
        {
            services.AddTransient<CorrelationIdHeaderHandler>();

            services.AddHttpContextAccessor();
            services.AddHeaderPropagation(options => options.Headers.Add("x-correlation-id"));
            services.AddHttpClient("api")
                .AddHeaderPropagation()
                .AddHttpMessageHandler<CorrelationIdHeaderHandler>();


            //dodati serilog correlation id neki nuget predavanje 8.2 23:20 timestamp
        }


	}
}

