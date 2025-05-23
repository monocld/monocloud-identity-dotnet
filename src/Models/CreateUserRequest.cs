using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The Create User Request class.
/// </summary>
public class CreateUserRequest
{
   /// <summary>
   /// The unique username for the user.
   /// </summary>
   public string? Username { get; set; }

   /// <summary>
   /// The user&#39;s email address.
   /// </summary>
   public string? Email { get; set; }

   /// <summary>
   /// Indicates whether the user&#39;s email address is verified.
   /// </summary>
   public bool? EmailVerified { get; set; }

   /// <summary>
   /// The user&#39;s phone number, starting with a &#x60;+&#x60; followed by the country code.
   /// </summary>
   public string? PhoneNumber { get; set; }

   /// <summary>
   /// Indicates whether the user&#39;s phone number is verified.
   /// </summary>
   public bool? PhoneNumberVerified { get; set; }

   /// <summary>
   /// The password for the user, which will be used for authentication.
   /// </summary>
   public string? Password { get; set; }

   /// <summary>
   /// The password hash for the user, which will be used for authentication.
   /// </summary>
   public string? PasswordHash { get; set; }

   /// <summary>
   /// The algorithm used the hash the password for the user.
   /// </summary>
   public PasswordAlgorithms? PasswordHashAlgorithm { get; set; }

   /// <summary>
   /// Specifies whether the specified password is temporary and will require the user to reset their password on the next sign-in.
   /// </summary>
   public bool? IsTemporaryPassword { get; set; }

   /// <summary>
   /// The user&#39;s full name.
   /// </summary>
   public string? Name { get; set; }

   /// <summary>
   /// The user&#39;s given (first) name.
   /// </summary>
   public string? GivenName { get; set; }

   /// <summary>
   /// The user&#39;s middle name or initial.
   /// </summary>
   public string? MiddleName { get; set; }

   /// <summary>
   /// The user&#39;s family (last) name.
   /// </summary>
   public string? FamilyName { get; set; }

   /// <summary>
   /// The user&#39;s preferred nickname.
   /// </summary>
   public string? Nickname { get; set; }

   /// <summary>
   /// The URI pointing to the user&#39;s profile picture.
   /// </summary>
   public string? Picture { get; set; }

   /// <summary>
   /// Specifies whether the password policy check should be skipped.
   /// </summary>
   public bool? SkipPasswordPolicyChecks { get; set; }

   /// <summary>
   /// Specifies whether the identifier restriction checks should be skipped.
   /// </summary>
   public bool? SkipIdentifierRestrictionChecks { get; set; }

   /// <summary>
   /// Specifies whether the users profile should conform to the options requirements.
   /// </summary>
   public bool? SkipConformanceChecks { get; set; }
}


