using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The User Connection response class
/// </summary>
public class UserConnection
{
   /// <summary>
   /// The identity providers the account is connected to.
   /// </summary>
   public IdPs Idp { get; set; }

   /// <summary>
   /// Specifies the ID of the user in the identity provider.
   /// </summary>
   public string ConnectionId { get; set; }
}


