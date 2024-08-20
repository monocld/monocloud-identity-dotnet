using System;
using System.Collections.Generic;
using MonoCloud.SDK.Core.Helpers;
using System.Text.Json.Serialization;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The Patch Group class.
/// </summary>
[JsonConverter(typeof(PatchConverter<PatchGroupRequest>))]
public class PatchGroupRequest
{
   /// <summary>
   /// Gets or sets the name for this group.
   /// </summary>
   public Optional<string> Name { get; set; }

   /// <summary>
   /// Gets or sets the description for this group.
   /// </summary>
   public Optional<string?> Description { get; set; }

   /// <summary>
   /// Specifies if the group should be assigned to new users by default
   /// </summary>
   public Optional<bool> IsAutoAssigned { get; set; }
}


