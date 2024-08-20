using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The External Authenticator Disconnect Request class.
/// </summary>
public class ExternalAuthenticatorDisconnectRequest
{
   /// <summary>
   /// External Authenticator to be disconnected
   /// </summary>
   public ExternalAuthenticators? Authenticator { get; set; }

   /// <summary>
   /// Provider User Id of the external authenticator.
   /// </summary>
   public string ProviderUserId { get; set; }
}


