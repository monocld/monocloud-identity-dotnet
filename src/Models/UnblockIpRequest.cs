using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.Identity.Models;

/// <summary>
/// The Unblock IP Request class.
/// </summary>
public class UnblockIpRequest
{
   /// <summary>
   /// The IP address to be unblocked. Use &#39;all&#39; to unblock all IP addresses associated with the user.
   /// </summary>
   public string IpAddress { get; set; }
}


