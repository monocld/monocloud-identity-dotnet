using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.UsersBackend.Models;

/// <summary>
/// The User Passkey response class
/// </summary>
public class UserPasskey
{
   /// <summary>
   /// Id of the passkey
   /// </summary>
   public string Id { get; set; }

   /// <summary>
   /// Public key of passkey
   /// </summary>
   public string PublicKey { get; set; }

   /// <summary>
   /// Authenticator Guid of the passkey
   /// </summary>
   public Guid AuthenticatorId { get; set; }

   /// <summary>
   /// Indicates whether the passkey is backed up by the authenticator
   /// </summary>
   public bool IsBackedUp { get; set; }

   /// <summary>
   /// Indicates whether the passkey is a multi device key. A passkey is multi-device when the passkey is backup eligible.
   /// </summary>
   public bool IsMultiDevice { get; set; }

   /// <summary>
   /// The user agent user used to register the passkey.
   /// </summary>
   public string UserAgent { get; set; }

   /// <summary>
   /// Specifies the creation time of the user (in Epoch).
   /// </summary>
   public long CreationTime { get; set; }
}


