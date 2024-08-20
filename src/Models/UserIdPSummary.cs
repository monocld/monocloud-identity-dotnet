using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The User IDP Summary response class
/// </summary>
public class UserIdPSummary
{
   /// <summary>
   /// Specifies the External Authenticator.
   /// </summary>
   public ExternalAuthenticators Authenticator { get; set; }

   /// <summary>
   /// Specifies the idp user Id.
   /// </summary>
   public string ProviderUserId { get; set; }
}


