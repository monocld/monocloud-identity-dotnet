using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The User Consent Scope response class
/// </summary>
public class UserConsentScope
{
   /// <summary>
   /// The consented scope name.
   /// </summary>
   public string Scope { get; set; }

   /// <summary>
   /// The time (in Epoch) at which the consent was granted for the scope.
   /// </summary>
   public DateTime GrantedOn { get; set; }

   /// <summary>
   /// The time (in Epoch) at which the consent will expire.
   /// </summary>
   public DateTime? Expiration { get; set; }
}


