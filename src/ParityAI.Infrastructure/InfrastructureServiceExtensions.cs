﻿using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using ParityAI.Core.Interfaces;
using ParityAI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ParityAI.Infrastructure.OpenAI.Agents.ParityAgent.Tools;
using ParityAI.Infrastructure.ChatAgents;

namespace ParityAI.Infrastructure;
public static class InfrastructureServiceExtensions
{
  public static IServiceCollection AddInfrastructureServices(
    this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger)
  {
    string? connectionString = config.GetConnectionString("SqliteConnection");
    Guard.Against.Null(connectionString);
    services.AddDbContext<AppDbContext>(options =>
     options.UseSqlite(connectionString));

    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>))
           .AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>))
           .AddScoped<IParityTool, ModuloParityTool>()
           .AddScoped<IParityTool, BitwiseParityTool>()
           .AddScoped<IChatAgent, TestAgent>();


    logger.LogInformation("{Project} services registered", "Infrastructure");

    return services;
  }
}
