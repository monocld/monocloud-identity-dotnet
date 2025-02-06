using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The Set Password Request class.
/// </summary>
public class SetPasswordRequest
{
   /// <summary>
   /// The password for the user, which will be used for authentication.
   /// </summary>
   public string? Password { get; set; }

   /// <summary>
   /// The password hash for the user, which will be used for authentication.
   /// </summary>
   public string? PasswordHash { get; set; }

   /// <summary>
   /// The algorithm used the hash the password for the user.
   /// </summary>
   public PasswordAlgorithms? PasswordHashAlgorithm { get; set; }

   /// <summary>
   /// Specifies whether the specified password is temporary and will require the user to reset their password on the next sign-in.
   /// </summary>
   public bool? IsTemporaryPassword { get; set; }

   /// <summary>
   /// Specifies whether the password policy check should be skipped.
   /// </summary>
   public bool? SkipPasswordPolicyChecks { get; set; }

   /// <summary>
   /// Indicates whether to revoke all sessions associated with the user when updating the password.
   /// </summary>
   public bool? RevokeSessions { get; set; }
}


