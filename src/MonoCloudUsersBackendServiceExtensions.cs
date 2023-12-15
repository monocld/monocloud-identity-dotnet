using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MonoCloud.SDK.Core.Base;
using System;
using System.Net.Http;

namespace MonoCloud.SDK.UsersBackend;

public static class MonoCloudUsersBackendServiceExtensions
{
  public static IServiceCollection AddMonoCloudUsersBackendClient(this IServiceCollection services, IConfiguration configuration) =>
    services.AddMonoCloudUsersBackendClient(configuration, null);

  public static IServiceCollection AddMonoCloudUsersBackendClient(this IServiceCollection services, Action<MonoCloudUsersBackendOptions> options) =>
    services.AddMonoCloudUsersBackendClient(null, options);

  public static IServiceCollection AddMonoCloudUsersBackendClient(this IServiceCollection services, IConfiguration? configuration, Action<MonoCloudUsersBackendOptions>? options)
  {
    string? domain = null;
    string? apiKey = null;
    int? timeout = null;

    if (configuration is not null)
    {
      var monocloudSection = configuration.GetSection("MonoCloud").GetSection("UsersBackend");
      domain = monocloudSection["Domain"];
      apiKey = monocloudSection["ApiKey"];

      if (int.TryParse(monocloudSection["Timeout"], out var result))
      {
        timeout = result;
      }
    }

    if (options is not null)
    {
      var settings = new MonoCloudUsersBackendOptions();
      options.Invoke(settings);

      if (settings.Domain is not null)
      {
        domain = settings.Domain;
      }

      if (settings.ApiKey is not null)
      {
        apiKey = settings.ApiKey;
      }

      if (settings.Timeout.HasValue)
      {
        timeout = settings.Timeout.Value.Seconds;
      }
    }

    if (domain is null || string.IsNullOrEmpty(domain))
    {
      throw new ArgumentNullException(nameof(MonoCloudUsersBackendOptions.Domain), "The domain for the MonoCloud UsersBackend client has not been set.");
    }

    if (apiKey is null || string.IsNullOrEmpty(apiKey))
    {
      throw new ArgumentNullException(nameof(MonoCloudUsersBackendOptions.ApiKey), "The api key for the MonoCloud UsersBackend client has not been set.");
    }

    var config = new MonoCloudConfig(domain, apiKey, timeout.HasValue ? TimeSpan.FromSeconds(timeout.Value) : null);

    var clientName = "MonoCloudUsersBackendClient";

    services.AddHttpClient(clientName)
      .ConfigureHttpClient(client =>
      {
        client.BaseAddress = new Uri($"{config.Domain}/api/");
        client.Timeout = config.Timeout;
        client.DefaultRequestHeaders.Add("X-API-KEY", config.ApiKey);
      });

    services.AddTransient(s =>
    {
      var factory = s.GetRequiredService<IHttpClientFactory>();
      var client = factory.CreateClient(clientName);
      return new MonoCloudUsersBackendClient(client);
    });

    return services;
  }
}
