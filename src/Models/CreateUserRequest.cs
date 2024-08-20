using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The Create User Request class.
/// </summary>
public class CreateUserRequest
{
   /// <summary>
   /// The user&#39;s username
   /// </summary>
   public string? Username { get; set; }

   /// <summary>
   /// The User&#39;s email
   /// </summary>
   public string? Email { get; set; }

   /// <summary>
   /// Specifies whether the email is verified or not.
   /// </summary>
   public bool? EmailVerified { get; set; }

   /// <summary>
   /// The user&#39;s phone number
   /// </summary>
   public string? PhoneNumber { get; set; }

   /// <summary>
   /// Specifies whether the phone number is verified or not.
   /// </summary>
   public bool? PhoneNumberVerified { get; set; }

   /// <summary>
   /// The password for the user
   /// </summary>
   public string? Password { get; set; }

   /// <summary>
   /// The user&#39;s name
   /// </summary>
   public string? Name { get; set; }

   /// <summary>
   /// The user&#39;s first name
   /// </summary>
   public string? GivenName { get; set; }

   /// <summary>
   /// The user&#39;s middle name
   /// </summary>
   public string? MiddleName { get; set; }

   /// <summary>
   /// The user&#39;s family name
   /// </summary>
   public string? FamilyName { get; set; }

   /// <summary>
   /// The user&#39;s nickname
   /// </summary>
   public string? Nickname { get; set; }

   /// <summary>
   /// The uri pointing to the user&#39;s picture
   /// </summary>
   public string? Picture { get; set; }
}


