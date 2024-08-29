using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The User Session response class
/// </summary>
public class UserSession
{
   /// <summary>
   /// The session key
   /// </summary>
   public string SessionKey { get; set; }

   /// <summary>
   /// The unique ID of the session
   /// </summary>
   public string SessionId { get; set; }

   /// <summary>
   /// The list of client ids which are associated with the session
   /// </summary>
   public List<string> ClientIds { get; set; }

   /// <summary>
   /// The initial time when the session was created
   /// </summary>
   public DateTime InitiatedAt { get; set; }

   /// <summary>
   /// The expiration time of the session
   /// </summary>
   public DateTime ExpiresAt { get; set; }

   /// <summary>
   /// The last updated time
   /// </summary>
   public DateTime LastUpdated { get; set; }

   /// <summary>
   /// The last session metadata
   /// </summary>
   public UserSessionMetadata LastMetadata { get; set; }
}


