using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The Create Group Request class.
/// </summary>
public class CreateGroupRequest
{
   /// <summary>
   /// The name of the group.
   /// </summary>
   public string Name { get; set; }

   /// <summary>
   /// The description of the group.
   /// </summary>
   public string? Description { get; set; }

   /// <summary>
   /// Specifies whether the group should be assigned to new users by default.
   /// </summary>
   public bool? IsAutoAssigned { get; set; }
}


