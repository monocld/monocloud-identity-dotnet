using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The User Client Grants response class
/// </summary>
public class UserClientGrants
{
   /// <summary>
   /// The unique ID of the client for which the grants were issued.
   /// </summary>
   public string ClientId { get; set; }

   /// <summary>
   /// Specifies whether or not the user has consented any scopes for the client.
   /// </summary>
   public bool Consented { get; set; }

   /// <summary>
   /// The number of refresh tokens issued.
   /// </summary>
   public long RefreshTokens { get; set; }

   /// <summary>
   /// The number of reference tokens issued.
   /// </summary>
   public long ReferenceTokens { get; set; }

   /// <summary>
   /// The number of authorization codes issued.
   /// </summary>
   public long AuthorizationCodes { get; set; }
}


