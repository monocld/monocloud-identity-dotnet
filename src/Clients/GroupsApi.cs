using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using MonoCloud.SDK.Core.Base;
using MonoCloud.SDK.Core.Exception;
using MonoCloud.SDK.Core.Helpers;
using MonoCloud.SDK.Identity.Models;

namespace MonoCloud.SDK.Identity.Clients;

/// <summary>
/// Represents a collection of functions to interact with the Groups Api endpoints
/// </summary>
public class GroupsClient : MonoCloudClientBase
{
  /// <summary>
  /// Initializes a new instance of the <see cref="GroupsClient"/> class.
  /// </summary>
  /// <param name="configuration">The <see cref="MonoCloudConfig">MonoCloud Configuration</see></param>
  /// <returns></returns>
  public GroupsClient(MonoCloudConfig configuration) : base(configuration)
  {
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="GroupsClient"/> class.
  /// </summary>
  /// <param name="httpClient">The <see cref="HttpClient"/> which will be used to communicate with the MonoCloud Api</param>
  /// <returns></returns>
  public GroupsClient(HttpClient httpClient) : base(httpClient)
  {
  }

  /// <summary>
  /// Get all groups
  /// </summary>
  /// <param name="page">Page Number</param>
  /// <param name="size">Page Size</param>
  /// <param name="filter">Value by which the groups needs to be filtered.</param>
  /// <param name="sort">Value in &#39;sort_key:sort_order&#39; format, by which results will be sorted. Sort order value can be &#39;1&#39; for ascending and &#39;-1&#39; for descending.  Acceptable sort key values are &#39;type&#39;, &#39;name&#39;, &#39;clients_assigned&#39;, &#39;users_assigned&#39;, &#39;last_assigned&#39;, &#39;creation_time&#39;, and &#39;last_updated&#39;</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>List&lt;Group&gt;</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<List<Group>, PageModel>> GetAllGroupsAsync(int? page = 1, int? size = 10, string? filter = default, string? sort = default, CancellationToken cancellationToken = default)
  { 
    var urlBuilder = new StringBuilder();
    urlBuilder.Append("groups?");

    if (page != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("page") + "=").Append(HttpUtility.UrlEncode(page.ToString())).Append("&");
    }

    if (size != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("size") + "=").Append(HttpUtility.UrlEncode(size.ToString())).Append("&");
    }

    if (filter != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("filter") + "=").Append(HttpUtility.UrlEncode(filter)).Append("&");
    }

    if (sort != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("sort") + "=").Append(HttpUtility.UrlEncode(sort)).Append("&");
    }

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("GET"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<List<Group>, PageModel>(request, cancellationToken);
  }

  /// <summary>
  /// Create a group
  /// </summary>
  /// <param name="createGroupRequest">Group&#39;s data</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>Group</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<Group>> CreateGroupAsync(CreateGroupRequest createGroupRequest, CancellationToken cancellationToken = default)
  { 
    if (createGroupRequest == null)
    {
      throw new ArgumentNullException(nameof(createGroupRequest));
    }
    
    var urlBuilder = new StringBuilder();
    urlBuilder.Append("groups?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("POST"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Content = new StringContent(Serialize(createGroupRequest), Encoding.UTF8, "application/json"),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<Group>(request, cancellationToken);
  }

  /// <summary>
  /// Get a group
  /// </summary>
  /// <param name="groupId">Group Id</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>Group</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<Group>> FindGroupByIdAsync(Guid groupId, CancellationToken cancellationToken = default)
  { 
    if (groupId == null)
    {
      throw new ArgumentNullException(nameof(groupId));
    }
    
    var encodedGroupId = HttpUtility.UrlEncode(groupId.ToString());

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"groups/{encodedGroupId}?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("GET"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<Group>(request, cancellationToken);
  }

  /// <summary>
  /// Delete a group
  /// </summary>
  /// <param name="groupId">Group Id</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns></returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse> DeleteGroupAsync(Guid groupId, CancellationToken cancellationToken = default)
  { 
    if (groupId == null)
    {
      throw new ArgumentNullException(nameof(groupId));
    }
    
    var encodedGroupId = HttpUtility.UrlEncode(groupId.ToString());

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"groups/{encodedGroupId}?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("DELETE"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
    };

    return ProcessRequestAsync(request, cancellationToken);
  }

  /// <summary>
  /// Update a group
  /// </summary>
  /// <param name="groupId">Group Id</param>
  /// <param name="patchGroupRequest">Data to be updated</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>Group</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<Group>> PatchGroupAsync(Guid groupId, PatchGroupRequest patchGroupRequest, CancellationToken cancellationToken = default)
  { 
    if (groupId == null)
    {
      throw new ArgumentNullException(nameof(groupId));
    }
    
    if (patchGroupRequest == null)
    {
      throw new ArgumentNullException(nameof(patchGroupRequest));
    }
    
    var encodedGroupId = HttpUtility.UrlEncode(groupId.ToString());

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"groups/{encodedGroupId}?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("PATCH"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Content = new StringContent(Serialize(patchGroupRequest), Encoding.UTF8, "application/json"),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<Group>(request, cancellationToken);
  }
}

