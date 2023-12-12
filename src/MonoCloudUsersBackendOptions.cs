using System;

namespace MonoCloud.SDK.UsersBackend;

public class MonoCloudUsersBackendOptions
{
  public string? Domain { get; set; }
  public string? ApiKey { get; set; }
  public TimeSpan? Timeout { get; set; }
}
