using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The User With Access Details Response Class
/// </summary>
public class UserWithAccessDetails
{
   /// <summary>
   /// Unique identifier of the user
   /// </summary>
   public string UserId { get; set; }

   /// <summary>
   /// Specifies whether the account has been disabled
   /// </summary>
   public bool Disabled { get; set; }

   /// <summary>
   /// User&#39;s Claims
   /// </summary>
   public Dictionary<string, object> Claims { get; set; }

   /// <summary>
   /// User&#39;s Public Data
   /// </summary>
   public Dictionary<string, object> PublicData { get; set; }

   /// <summary>
   /// User&#39;s Private Data
   /// </summary>
   public Dictionary<string, object> PrivateData { get; set; }

   /// <summary>
   /// List of registered emails of user
   /// </summary>
   public List<UserEmail> Emails { get; set; }

   /// <summary>
   /// List of registered phones of user
   /// </summary>
   public List<UserPhone> PhoneNumbers { get; set; }

   /// <summary>
   /// List of registered passkeys of user
   /// </summary>
   public List<UserPasskey> Passkeys { get; set; }

   /// <summary>
   /// List of registered idps of user
   /// </summary>
   public List<UserIdP> Idps { get; set; }

   /// <summary>
   /// Specifies the creation time of the user (in Epoch)
   /// </summary>
   public DateTime CreationTime { get; set; }

   /// <summary>
   /// Specifies the last update time of the user (in Epoch)
   /// </summary>
   public DateTime LastUpdated { get; set; }

   /// <summary>
   /// Registered username of the user.
   /// </summary>
   public UserUsername? Username { get; set; }

   /// <summary>
   /// Specifies whether the user has a password.
   /// </summary>
   public bool HasPassword { get; set; }

   /// <summary>
   /// Specifies the time (in Epoch) of last password update.
   /// </summary>
   public DateTime? PasswordUpdatedAt { get; set; }

   /// <summary>
   /// Total number of sign-in attempts.
   /// </summary>
   public int SignInCount { get; set; }

   /// <summary>
   /// Specifies the ip address from which the last sign in attempt was made.
   /// </summary>
   public string? LastSignInIp { get; set; }

   /// <summary>
   /// Specifies the time (in Epoch) at which the last sign in attempt was made.
   /// </summary>
   public DateTime? LastSignInAttempt { get; set; }

   /// <summary>
   /// Specifies whether the user has been locked out.
   /// </summary>
   public bool Blocked { get; set; }
}


