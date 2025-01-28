using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The User Phone response class
/// </summary>
public class UserPhone
{
   /// <summary>
   /// Unique identifier of the user phone.
   /// </summary>
   public Guid Id { get; set; }

   /// <summary>
   /// Specifies whether the phone is the primary phone of the user.
   /// </summary>
   public bool Primary { get; set; }

   /// <summary>
   /// Specifies whether the phone is verified or not.
   /// </summary>
   public bool Verified { get; set; }

   /// <summary>
   /// Specifies where the phone was originally collected from.
   /// </summary>
   public string? Source { get; set; }

   /// <summary>
   /// Specifies where the phone verification was done.
   /// </summary>
   public string? VerificationSource { get; set; }

   /// <summary>
   /// The phone number.
   /// </summary>
   public string Phone { get; set; }
}


