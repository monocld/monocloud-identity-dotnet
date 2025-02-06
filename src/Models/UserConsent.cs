using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The User Consent response class
/// </summary>
public class UserConsent
{
   /// <summary>
   /// The unique ID of the grant.
   /// </summary>
   public string Id { get; set; }

   /// <summary>
   /// The unique ID of the client for which the grant was issued.
   /// </summary>
   public string ClientId { get; set; }

   /// <summary>
   /// The time (in Epoch) at which the grant was created.
   /// </summary>
   public DateTime CreationTime { get; set; }

   /// <summary>
   /// A list of consented scopes.
   /// </summary>
   public List<UserConsentScope> Scopes { get; set; }
}


