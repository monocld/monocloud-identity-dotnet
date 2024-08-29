using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The Disable User Request class.
/// </summary>
public class DisableUserRequest
{
   /// <summary>
   /// Indicates whether to revoke all sessions associated with the user when disabling the account.
   /// </summary>
   public bool? RevokeSessions { get; set; }
}


