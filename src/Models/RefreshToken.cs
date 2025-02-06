using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The Refresh Token response class
/// </summary>
public class RefreshToken
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
   /// The unique ID of the session
   /// </summary>
   public string? SessionId { get; set; }

   /// <summary>
   /// A list of scopes associated with the token.
   /// </summary>
   public List<string> Scopes { get; set; }

   /// <summary>
   /// The time (in Epoch) at which the token will expire.
   /// </summary>
   public DateTime? Expiration { get; set; }

   /// <summary>
   /// The audiences for which the token was issued.
   /// </summary>
   public List<string> Audiences { get; set; }

   /// <summary>
   /// The issuer of the token.
   /// </summary>
   public string? Issuer { get; set; }
}


