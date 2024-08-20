using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The User Ip Access Details response class
/// </summary>
public class UserIpAccessDetails
{
   /// <summary>
   /// Number of unsuccessful logins.
   /// </summary>
   public int FailureCount { get; set; }

   /// <summary>
   /// Specifies the time upto which the user is blocked.
   /// </summary>
   public DateTime? BlockUntil { get; set; }

   /// <summary>
   /// Total number of sign-in attempts.
   /// </summary>
   public int LoginCount { get; set; }

   /// <summary>
   /// Specifies the ip address from which the sign in attempt was made.
   /// </summary>
   public string Ip { get; set; }

   /// <summary>
   /// Specifies the time (in Epoch) at which the last sign in attempt was made.
   /// </summary>
   public DateTime LastLoginAttempt { get; set; }
}


