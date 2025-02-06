using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The Reset Password Response
/// </summary>
public class ResetPasswordResponse
{
   /// <summary>
   /// The generated magic link for the password reset request.
   /// </summary>
   public string Link { get; set; }

   /// <summary>
   /// The expiry date for the generated magic link (in epoch).
   /// </summary>
   public DateTime ExpiresAt { get; set; }

   /// <summary>
   /// Specifies whether the password reset email was sent to the user.
   /// </summary>
   public bool EmailSent { get; set; }
}


