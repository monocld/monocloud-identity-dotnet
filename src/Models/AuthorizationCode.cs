using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The Authorization Code response class
/// </summary>
public class AuthorizationCode
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
   /// A list of scopes that were requested.
   /// </summary>
   public List<string> AuthorizedScopes { get; set; }

   /// <summary>
   /// The time (in Epoch) at which the code will expire.
   /// </summary>
   public DateTime? Expiration { get; set; }
}


