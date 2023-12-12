using System.Net.Http;
using MonoCloud.SDK.UsersBackend.Clients;
using MonoCloud.SDK.Core.Base;

namespace MonoCloud.SDK.UsersBackend;

/// <summary>
/// The MonoCloud UsersBackend Client Class
/// </summary>
public class MonoCloudUsersBackendClient : UsersClient
{ 
  /// <summary>
  /// Initializes the MonoCloud UsersBackend Client Class
  /// </summary>
  /// <param name="configuration">The <see cref="MonoCloudConfig">MonoCloud Configuration</see></param>
  public MonoCloudUsersBackendClient(MonoCloudConfig configuration) : base(configuration)
  { 
  }


  /// <summary>
  /// Initializes the MonoCloud UsersBackend Client Class
  /// </summary>
  /// <param name="httpClient">The <see cref="HttpClient"/> which will be used to communicate with the MonoCloud Api</param>
  public MonoCloudUsersBackendClient(HttpClient httpClient) : base(httpClient)
  { 
  }
}
