using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The User External Provider response class
/// </summary>
public class UserExternalProvider
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


