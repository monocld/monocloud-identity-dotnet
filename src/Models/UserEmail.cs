using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.UsersBackend.Models;

/// <summary>
/// The User Email response class
/// </summary>
public class UserEmail
{
   /// <summary>
   /// Unique identifier of the user email.
   /// </summary>
   public Guid Id { get; set; }

   /// <summary>
   /// Specifies whether the email is the primary email of the user.
   /// </summary>
   public bool Primary { get; set; }

   /// <summary>
   /// A list of identity providers the email is connected to.
   /// </summary>
   public List<IdPs> Idps { get; set; }

   /// <summary>
   /// A list of authenticators the email is connected to.
   /// </summary>
   public List<Authenticators> Authenticators { get; set; }

   /// <summary>
   /// Specifies whether the email is verified or not.
   /// </summary>
   public bool Verified { get; set; }

   /// <summary>
   /// The email id.
   /// </summary>
   public string Email { get; set; }
}


