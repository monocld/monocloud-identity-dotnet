using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The Create Group Request class.
/// </summary>
public class CreateGroupRequest
{
   /// <summary>
   /// Gets or sets the name for this group.
   /// </summary>
   public string Name { get; set; }

   /// <summary>
   /// Gets or sets the description for this group.
   /// </summary>
   public string? Description { get; set; }

   /// <summary>
   /// Specifies if the group should be assigned to new users by default
   /// </summary>
   public bool? IsAutoAssigned { get; set; }
}


