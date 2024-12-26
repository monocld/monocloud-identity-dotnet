using System;
using System.Collections.Generic;
using MonoCloud.SDK.Core.Helpers;
using System.Text.Json.Serialization;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The Update Claims Request.
/// </summary>
[JsonConverter(typeof(PatchConverter<UpdateClaimsRequest>))]
public class UpdateClaimsRequest
{
   /// <summary>
   /// The user&#39;s full name.
   /// </summary>
   public Optional<string?> Name { get; set; }

   /// <summary>
   /// The user&#39;s given (first) name.
   /// </summary>
   public Optional<string?> GivenName { get; set; }

   /// <summary>
   /// The user&#39;s middle name or initial.
   /// </summary>
   public Optional<string?> MiddleName { get; set; }

   /// <summary>
   /// The user&#39;s family (last) name.
   /// </summary>
   public Optional<string?> FamilyName { get; set; }

   /// <summary>
   /// The user&#39;s preferred nickname.
   /// </summary>
   public Optional<string?> Nickname { get; set; }

   /// <summary>
   /// The URI pointing to the user&#39;s profile picture.
   /// </summary>
   public Optional<string?> Picture { get; set; }
}


