using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The User Username response class
/// </summary>
public class UserUsername
{
   /// <summary>
   /// Unique identifier of the user email.
   /// </summary>
   public Guid Id { get; set; }

   /// <summary>
   /// The username.
   /// </summary>
   public string Username { get; set; }

   /// <summary>
   /// Specifies where the username was originally collected from.
   /// </summary>
   public string? Source { get; set; }
}


