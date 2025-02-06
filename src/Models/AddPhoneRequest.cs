using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The Add Phone Request.
/// </summary>
public class AddPhoneRequest
{
   /// <summary>
   /// The phone number to add, starting with a &#x60;+&#x60; followed by the country code.
   /// </summary>
   public string PhoneNumber { get; set; }

   /// <summary>
   /// Indicates whether the phone number is verified.
   /// </summary>
   public bool? IsVerified { get; set; }

   /// <summary>
   /// Specifies whether the phone restriction checks should be skipped.
   /// </summary>
   public bool? SkipRestrictionChecks { get; set; }
}


