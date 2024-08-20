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
   /// A list of identity providers the username is connected to.
   /// </summary>
   public List<IdPs> Idps { get; set; }

   /// <summary>
   /// A list of authenticators the username is connected to.
   /// </summary>
   public List<Authenticators> Authenticators { get; set; }

   /// <summary>
   /// The username.
   /// </summary>
   public string Username { get; set; }
}


