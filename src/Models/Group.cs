using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The Group response class
/// </summary>
public class Group
{
   /// <summary>
   /// Unique identifier of the group
   /// </summary>
   public Guid GroupId { get; set; }

   /// <summary>
   /// Specifies the type of the group
   /// </summary>
   public GroupTypes Type { get; set; }

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
   public bool IsAutoAssigned { get; set; }

   /// <summary>
   /// The number of users assigned to the group
   /// </summary>
   public long UsersAssigned { get; set; }

   /// <summary>
   /// The number of clients assigned to the group
   /// </summary>
   public long ClientsAssigned { get; set; }

   /// <summary>
   /// Specifies the creation time of the group (in Epoch)
   /// </summary>
   public DateTime CreationTime { get; set; }

   /// <summary>
   /// Specifies the last update time of the group (in Epoch)
   /// </summary>
   public DateTime LastUpdated { get; set; }

   /// <summary>
   /// Specifies the last assigned time of the group (in Epoch)
   /// </summary>
   public DateTime LastAssigned { get; set; }
}


