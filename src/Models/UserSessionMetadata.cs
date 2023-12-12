using System;
using System.Collections.Generic;

namespace MonoCloud.SDK.UsersBackend.Models;

/// <summary>
/// The User Session Metadata response class
/// </summary>
public class UserSessionMetadata
{
   /// <summary>
   /// The City.
   /// </summary>
   public string? City { get; set; }

   /// <summary>
   /// The Country.
   /// </summary>
   public string? Country { get; set; }

   /// <summary>
   /// The Region.
   /// </summary>
   public string? Region { get; set; }

   /// <summary>
   /// Latitude.
   /// </summary>
   public string? Latitude { get; set; }

   /// <summary>
   /// Longitude.
   /// </summary>
   public string? Longitude { get; set; }

   /// <summary>
   /// Ip Address from which the authentication request was made.
   /// </summary>
   public string? IpAddress { get; set; }

   /// <summary>
   /// Device information of the authentication request.
   /// </summary>
   public string? UserAgent { get; set; }
}


