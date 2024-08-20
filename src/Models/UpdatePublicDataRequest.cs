using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The Update Public Data Request class.
/// </summary>
public class UpdatePublicDataRequest
{
   /// <summary>
   /// User&#39;s Public Data
   /// </summary>
   public Dictionary<string, object> PublicData { get; set; }
}


