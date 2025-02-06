using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The Verify Email Response
/// </summary>
public class VerifyEmailResponse
{
   /// <summary>
   /// The expiry date for the generated magic link (in epoch).
   /// </summary>
   public DateTime ExpiresAt { get; set; }

   /// <summary>
   /// Specifies whether the verification email was sent to the user.
   /// </summary>
   public bool EmailSent { get; set; }
}


