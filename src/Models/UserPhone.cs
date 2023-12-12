using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.UsersBackend.Models;

/// <summary>
/// The User Phone response class
/// </summary>
public class UserPhone
{
   /// <summary>
   /// Unique identifier of the user phone.
   /// </summary>
   public Guid Id { get; set; }

   /// <summary>
   /// Specifies whether the phone is the primary phone of the user.
   /// </summary>
   public bool Primary { get; set; }

   /// <summary>
   /// A list of identity providers the phone is connected to.
   /// </summary>
   public List<IdPs> Idps { get; set; }

   /// <summary>
   /// A list of authenticators the phone is connected to.
   /// </summary>
   public List<Authenticators> Authenticators { get; set; }

   /// <summary>
   /// Specifies whether the phone is verified or not.
   /// </summary>
   public bool Verified { get; set; }

   /// <summary>
   /// The phone number.
   /// </summary>
   public string Phone { get; set; }
}


