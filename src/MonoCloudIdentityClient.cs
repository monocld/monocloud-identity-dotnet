using System.Net.Http;
using MonoCloud.SDK.Identity.Clients;
using MonoCloud.SDK.Core.Base;

namespace MonoCloud.SDK.Identity;

/// <summary>
/// The MonoCloud Identity Client Class
/// </summary>
public class MonoCloudIdentityClient
{ 
  /// <summary>
  /// Gets the GroupsClient instance to interact with the Groups Api endpoints
  /// </summary>
  public GroupsClient Groups { get; }

  /// <summary>
  /// Gets the UsersClient instance to interact with the Users Api endpoints
  /// </summary>
  public UsersClient Users { get; }

  /// <summary>
  /// Initializes the MonoCloud Identity Client Class
  /// </summary>
  /// <param name="configuration">The <see cref="MonoCloudConfig">MonoCloud Configuration</see></param>
  public MonoCloudIdentityClient(MonoCloudConfig configuration)
  { 
    Groups = new GroupsClient(configuration);
    Users = new UsersClient(configuration);
  }


  /// <summary>
  /// Initializes the MonoCloud Identity Client Class
  /// </summary>
  /// <param name="httpClient">The <see cref="HttpClient"/> which will be used to communicate with the MonoCloud Api</param>
  public MonoCloudIdentityClient(HttpClient httpClient)
  { 
    Groups = new GroupsClient(httpClient);
    Users = new UsersClient(httpClient);
  }
}
