﻿using ParityAI.Core.Interfaces;
using ParityAI.Infrastructure;
using ParityAI.Infrastructure.Email;

namespace ParityAI.Web.Configurations;

public static class ServiceConfigs
{
  public static IServiceCollection AddServiceConfigs(this IServiceCollection services, ILogger logger, WebApplicationBuilder builder)
  {
    services.AddInfrastructureServices(builder.Configuration, logger)
            .AddMediatrConfigs();

    if (builder.Environment.IsDevelopment())
    {
      // Use a local test email server
      // See: https://ardalis.com/configuring-a-local-test-email-server/
      services.AddScoped<IEmailSender, MimeKitEmailSender>();

      // Otherwise use this:
      //builder.Services.AddScoped<IEmailSender, FakeEmailSender>();

    }
    else
    {
      services.AddScoped<IEmailSender, MimeKitEmailSender>();
    }

    logger.LogInformation("{Project} services registered", "Mediatr and Email Sender");

    return services;
  }


}
