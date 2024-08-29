using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The Update Private Data Request class.
/// </summary>
public class UpdatePrivateDataRequest
{
   /// <summary>
   /// An object containing fields to update within the user&#39;s private data. Only the data provided in the object will be updated. Field values can be strings, booleans, numbers, arrays, or objects. To unset a key, pass a null value for that key.
   /// </summary>
   public Dictionary<string, object> PrivateData { get; set; }
}


