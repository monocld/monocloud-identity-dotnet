using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The User Email response class
/// </summary>
public class UserEmail
{
   /// <summary>
   /// Unique identifier of the user email.
   /// </summary>
   public Guid Id { get; set; }

   /// <summary>
   /// Specifies whether the email is the primary email of the user.
   /// </summary>
   public bool Primary { get; set; }

   /// <summary>
   /// Specifies whether the email is verified or not.
   /// </summary>
   public bool Verified { get; set; }

   /// <summary>
   /// Specifies where the email was originally collected from.
   /// </summary>
   public string? Source { get; set; }

   /// <summary>
   /// Specifies where the email verification was done.
   /// </summary>
   public string? VerificationSource { get; set; }

   /// <summary>
   /// The email id.
   /// </summary>
   public string Email { get; set; }
}


