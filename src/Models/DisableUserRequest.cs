using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The Unblock Ip Request class.
/// </summary>
public class DisableUserRequest
{
   /// <summary>
   /// Specifies whether to revoke all sessions associated with the user.
   /// </summary>
   public bool? RevokeSessions { get; set; }
}


