using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The User Summary response class
/// </summary>
public class UserSummary
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
   /// List of providers that the user account is connected to
   /// </summary>
   public List<UserConnection> Connections { get; set; }

   /// <summary>
   /// User&#39;s Claims
   /// </summary>
   public Dictionary<string, object> Claims { get; set; }

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
   /// A flag indicating that the user must change their password on next sign-in
   /// </summary>
   public bool ForcePasswordReset { get; set; }

   /// <summary>
   /// List of registered external providers of user
   /// </summary>
   public List<UserExternalProviderSummary> ExternalProviders { get; set; }

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
   /// Specifies whether the user has been locked out.
   /// </summary>
   public bool Blocked { get; set; }

   /// <summary>
   /// Total number of sign-in attempts.
   /// </summary>
   public int SignInAttemptsCount { get; set; }

   /// <summary>
   /// Specifies the time (in Epoch) at which the last sign in attempt was made.
   /// </summary>
   public DateTime? LastSignInAttempt { get; set; }

   /// <summary>
   /// Specifies the ip address from which the last sign in attempt was made.
   /// </summary>
   public string? LastSignInAttemptIp { get; set; }

   /// <summary>
   /// Specifies the time (in Epoch) at which the last activity of the user was recorded.
   /// </summary>
   public DateTime? LastActivity { get; set; }

   /// <summary>
   /// The last known city of the user.
   /// </summary>
   public string? LastKnownCity { get; set; }

   /// <summary>
   /// The last known country of the user.
   /// </summary>
   public string? LastKnownCountry { get; set; }

   /// <summary>
   /// The last known region of the user.
   /// </summary>
   public string? LastKnownRegion { get; set; }
}


