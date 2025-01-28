using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The User External Provider Summary response class
/// </summary>
public class UserExternalProviderSummary
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


