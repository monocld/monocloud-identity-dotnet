using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The External Authenticator Disconnect Request class.
/// </summary>
public class ExternalAuthenticatorDisconnectRequest
{
   /// <summary>
   /// The external authenticator to be disconnected.
   /// </summary>
   public ExternalAuthenticators? Authenticator { get; set; }

   /// <summary>
   /// The ID of the user in the external provider&#39;s system.
   /// </summary>
   public string ProviderUserId { get; set; }
}


