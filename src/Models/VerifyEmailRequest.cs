using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The Verify Email Request.
/// </summary>
public class VerifyEmailRequest
{
   /// <summary>
   /// Specifies the expiry time for the verification link (in seconds).
   /// </summary>
   public int? Expiry { get; set; }
}


