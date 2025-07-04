﻿using Ardalis.SharedKernel;
using MediatR;
using System.Reflection;
using ParityAI.UseCases.Chats.SendMessages;

namespace ParityAI.Web.Configurations;

public static class MediatrConfigs
{
  public static IServiceCollection AddMediatrConfigs(this IServiceCollection services)
  {
    var mediatRAssemblies = new[]
      {
        // Assembly.GetAssembly(typeof(Contributor)), // Core
        Assembly.GetAssembly(typeof(SendMessagesQuery)) // UseCases
      };

    services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatRAssemblies!))
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
            .AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();

    return services;
  }
}
