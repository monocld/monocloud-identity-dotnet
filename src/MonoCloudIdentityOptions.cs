using System;

namespace MonoCloud.SDK.Identity;

public class MonoCloudIdentityOptions
{
  public string? Domain { get; set; }
  public string? ApiKey { get; set; }
  public TimeSpan? Timeout { get; set; }
}
