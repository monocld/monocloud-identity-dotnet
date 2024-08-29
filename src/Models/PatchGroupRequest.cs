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
   /// The name of the group.
   /// </summary>
   public Optional<string> Name { get; set; }

   /// <summary>
   /// The description of the group.
   /// </summary>
   public Optional<string?> Description { get; set; }

   /// <summary>
   /// Specifies whether the group should be assigned to new users by default.
   /// </summary>
   public Optional<bool> IsAutoAssigned { get; set; }
}


