using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The User Group response class
/// </summary>
public class UserGroup
{
   /// <summary>
   /// Unique ID of the group
   /// </summary>
   public Guid GroupId { get; set; }

   /// <summary>
   /// The user ID
   /// </summary>
   public string UserId { get; set; }

   /// <summary>
   /// Specifies the creation time of the user group (in Epoch).
   /// </summary>
   public DateTime CreationTime { get; set; }

   /// <summary>
   /// Name of the group
   /// </summary>
   public string GroupName { get; set; }
}


