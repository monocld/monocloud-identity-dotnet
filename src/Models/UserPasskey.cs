using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The User Passkey response class
/// </summary>
public class UserPasskey
{
   /// <summary>
   /// A human-readable name for the passkey
   /// </summary>
   public string? Name { get; set; }

   /// <summary>
   /// Unique identifier of the passkey received from the authenticator
   /// </summary>
   public string PasskeyId { get; set; }

   /// <summary>
   /// Public key of passkey
   /// </summary>
   public string PublicKey { get; set; }

   /// <summary>
   /// Authenticator Guid of the passkey
   /// </summary>
   public Guid AaGuid { get; set; }

   /// <summary>
   /// Indicates whether the passkey is backed up by the authenticator
   /// </summary>
   public bool BackupState { get; set; }

   /// <summary>
   /// Indicates whether the passkey is backup eligible. A passkey is considered as a multi-device when it is backup eligible.
   /// </summary>
   public bool BackupEligibility { get; set; }

   /// <summary>
   /// Specifies whether there was a user interaction while authenticating using the passkey.
   /// </summary>
   public bool UserPresent { get; set; }

   /// <summary>
   /// Specifies whether there was a user verification while authenticating using the passkey.
   /// </summary>
   public bool UserVerified { get; set; }

   /// <summary>
   /// The user agent user used to register the passkey.
   /// </summary>
   public string UserAgent { get; set; }
}


