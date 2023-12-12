using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.UsersBackend.Models;

/// <summary>
/// The User IDP response class
/// </summary>
public class UserIdP
{
   /// <summary>
   /// Specifies the External Authenticator.
   /// </summary>
   public ExternalAuthenticators Authenticator { get; set; }

   /// <summary>
   /// Specifies the idp user Id.
   /// </summary>
   public string ProviderUserId { get; set; }

   /// <summary>
   /// Claims related to the idp.
   /// </summary>
   public Dictionary<string, object> Claims { get; set; }
}


