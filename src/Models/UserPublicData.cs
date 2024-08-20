using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The User Public Data response class
/// </summary>
public class UserPublicData
{
   /// <summary>
   /// User&#39;s Public Data
   /// </summary>
   public Dictionary<string, object> PublicData { get; set; }
}


