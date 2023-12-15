using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.UsersBackend.Models;

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
   /// List of registered idps of user
   /// </summary>
   public List<UserIdPSummary> Idps { get; set; }

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
}


