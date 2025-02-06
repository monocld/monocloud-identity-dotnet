using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The Add Email Request.
/// </summary>
public class AddEmailRequest
{
   /// <summary>
   /// The email address to add.
   /// </summary>
   public string Email { get; set; }

   /// <summary>
   /// Indicates whether the email address is verified.
   /// </summary>
   public bool? IsVerified { get; set; }

   /// <summary>
   /// Specifies whether the email restriction checks should be skipped.
   /// </summary>
   public bool? SkipRestrictionChecks { get; set; }
}


