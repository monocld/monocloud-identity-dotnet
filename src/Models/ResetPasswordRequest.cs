using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The Reset Password Request.
/// </summary>
public class ResetPasswordRequest
{
   /// <summary>
   /// Specifies whether to send the password reset email to the user.
   /// </summary>
   public bool? SendEmail { get; set; }

   /// <summary>
   /// Specifies the expiry time for the password reset link (in seconds).
   /// </summary>
   public int? Expiry { get; set; }
}


