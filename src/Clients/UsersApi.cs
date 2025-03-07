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
/// Represents a collection of functions to interact with the Users Api endpoints
/// </summary>
public class UsersClient : MonoCloudClientBase
{
  /// <summary>
  /// Initializes a new instance of the <see cref="UsersClient"/> class.
  /// </summary>
  /// <param name="configuration">The <see cref="MonoCloudConfig">MonoCloud Configuration</see></param>
  /// <returns></returns>
  public UsersClient(MonoCloudConfig configuration) : base(configuration)
  {
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="UsersClient"/> class.
  /// </summary>
  /// <param name="httpClient">The <see cref="HttpClient"/> which will be used to communicate with the MonoCloud Api</param>
  /// <returns></returns>
  public UsersClient(HttpClient httpClient) : base(httpClient)
  {
  }

  /// <summary>
  /// Get all users
  /// </summary>
  /// <param name="page">The page number to retrieve.</param>
  /// <param name="size">The number of items per page.</param>
  /// <param name="filter">A query filter to apply when searching for users.</param>
  /// <param name="sort">Specifies the sort criteria in the &#39;sort_key:sort_order&#39; format. The sort order value can be &#39;1&#39; for ascending and &#39;-1&#39; for descending.  Acceptable sort key values are &#39;creation_time&#39;, and &#39;last_updated&#39;.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>List&lt;UserSummary&gt;</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<List<UserSummary>, PageModel>> GetAllUsersAsync(int? page = 1, int? size = 10, string? filter = default, string? sort = default, CancellationToken cancellationToken = default)
  { 
    var urlBuilder = new StringBuilder();
    urlBuilder.Append("users?");

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

    return ProcessRequestAsync<List<UserSummary>, PageModel>(request, cancellationToken);
  }

  /// <summary>
  /// Create a user
  /// </summary>
  /// <param name="createUserRequest">The create user request.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>User</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<User>> CreateUserAsync(CreateUserRequest createUserRequest, CancellationToken cancellationToken = default)
  { 
    if (createUserRequest == null)
    {
      throw new ArgumentNullException(nameof(createUserRequest));
    }
    
    var urlBuilder = new StringBuilder();
    urlBuilder.Append("users?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("POST"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Content = new StringContent(Serialize(createUserRequest), Encoding.UTF8, "application/json"),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<User>(request, cancellationToken);
  }

  /// <summary>
  /// Get a user
  /// </summary>
  /// <param name="userId">The ID of the user whose profile information should be retrieved.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>User</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<User>> FindUserByIdAsync(string userId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}?");

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

    return ProcessRequestAsync<User>(request, cancellationToken);
  }

  /// <summary>
  /// Delete a user
  /// </summary>
  /// <param name="userId">The ID of the user to be deleted.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns></returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse> DeleteUserAsync(string userId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("DELETE"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
    };

    return ProcessRequestAsync(request, cancellationToken);
  }

  /// <summary>
  /// Enable a user
  /// </summary>
  /// <param name="userId">The ID of the user to be enabled.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>User</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<User>> EnableUserAsync(string userId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/enable?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("POST"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<User>(request, cancellationToken);
  }

  /// <summary>
  /// Disable a user
  /// </summary>
  /// <param name="userId">The ID of the user to be disabled.</param>
  /// <param name="disableUserRequest">The disable user request.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>User</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<User>> DisableUserAsync(string userId, DisableUserRequest disableUserRequest, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (disableUserRequest == null)
    {
      throw new ArgumentNullException(nameof(disableUserRequest));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/disable?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("POST"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Content = new StringContent(Serialize(disableUserRequest), Encoding.UTF8, "application/json"),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<User>(request, cancellationToken);
  }

  /// <summary>
  /// Unblock a user
  /// </summary>
  /// <param name="userId">The ID of the user whose account should be unblocked.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>User</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<User>> UnblockUserAsync(string userId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/unblock?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("POST"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<User>(request, cancellationToken);
  }

  /// <summary>
  /// Add or update username
  /// </summary>
  /// <param name="userId">The ID of the user whose username should be set.</param>
  /// <param name="updateUsernameRequest">The request body.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>User</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<User>> UpdateUsernameAsync(string userId, UpdateUsernameRequest updateUsernameRequest, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (updateUsernameRequest == null)
    {
      throw new ArgumentNullException(nameof(updateUsernameRequest));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/username?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("PUT"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Content = new StringContent(Serialize(updateUsernameRequest), Encoding.UTF8, "application/json"),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<User>(request, cancellationToken);
  }

  /// <summary>
  /// Remove username
  /// </summary>
  /// <param name="userId">The ID of the user whose username should be removed.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>User</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<User>> RemoveUsernameAsync(string userId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/username?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("DELETE"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<User>(request, cancellationToken);
  }

  /// <summary>
  /// Add an email
  /// </summary>
  /// <param name="userId">The ID of the user for whom the email should be added.</param>
  /// <param name="addEmailRequest">The request body</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>User</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<User>> AddEmailAsync(string userId, AddEmailRequest addEmailRequest, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (addEmailRequest == null)
    {
      throw new ArgumentNullException(nameof(addEmailRequest));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/emails?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("POST"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Content = new StringContent(Serialize(addEmailRequest), Encoding.UTF8, "application/json"),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<User>(request, cancellationToken);
  }

  /// <summary>
  /// Remove an email
  /// </summary>
  /// <param name="userId">The ID of the user whose email should be removed.</param>
  /// <param name="identifierId">The ID of the email to be removed.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>User</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<User>> RemoveEmailAsync(string userId, Guid identifierId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (identifierId == null)
    {
      throw new ArgumentNullException(nameof(identifierId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var encodedIdentifierId = HttpUtility.UrlEncode(identifierId.ToString());

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/emails/{encodedIdentifierId}?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("DELETE"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<User>(request, cancellationToken);
  }

  /// <summary>
  /// Set email as primary
  /// </summary>
  /// <param name="userId">The ID of the user whose email should be set as primary.</param>
  /// <param name="identifierId">The ID of the email to be set as primary.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>User</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<User>> SetPrimaryEmailAsync(string userId, Guid identifierId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (identifierId == null)
    {
      throw new ArgumentNullException(nameof(identifierId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var encodedIdentifierId = HttpUtility.UrlEncode(identifierId.ToString());

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/emails/{encodedIdentifierId}/primary?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("POST"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<User>(request, cancellationToken);
  }

  /// <summary>
  /// Mark email as verified
  /// </summary>
  /// <param name="userId">The ID of the user whose email is to be marked as verified.</param>
  /// <param name="identifierId">The ID of the email to be marked as verified.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>User</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<User>> SetEmailVerifiedAsync(string userId, Guid identifierId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (identifierId == null)
    {
      throw new ArgumentNullException(nameof(identifierId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var encodedIdentifierId = HttpUtility.UrlEncode(identifierId.ToString());

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/emails/{encodedIdentifierId}/verify?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("POST"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<User>(request, cancellationToken);
  }

  /// <summary>
  /// Mark email as unverified
  /// </summary>
  /// <param name="userId">The ID of the user whose email is to be marked as unverified.</param>
  /// <param name="identifierId">The ID of the email to be marked as unverified.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>User</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<User>> SetEmailUnverifiedAsync(string userId, Guid identifierId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (identifierId == null)
    {
      throw new ArgumentNullException(nameof(identifierId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var encodedIdentifierId = HttpUtility.UrlEncode(identifierId.ToString());

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/emails/{encodedIdentifierId}/unverify?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("POST"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<User>(request, cancellationToken);
  }

  /// <summary>
  /// Verify Email
  /// </summary>
  /// <param name="userId">The ID of the user whose email verification link is requested.</param>
  /// <param name="identifierId">The ID of the email to be verified.</param>
  /// <param name="verifyEmailRequest"></param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>VerifyEmailResponse</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<VerifyEmailResponse>> VerifyEmailAsync(string userId, Guid identifierId, VerifyEmailRequest verifyEmailRequest, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (identifierId == null)
    {
      throw new ArgumentNullException(nameof(identifierId));
    }
    
    if (verifyEmailRequest == null)
    {
      throw new ArgumentNullException(nameof(verifyEmailRequest));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var encodedIdentifierId = HttpUtility.UrlEncode(identifierId.ToString());

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/emails/{encodedIdentifierId}/verify/link?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("POST"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Content = new StringContent(Serialize(verifyEmailRequest), Encoding.UTF8, "application/json"),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<VerifyEmailResponse>(request, cancellationToken);
  }

  /// <summary>
  /// Add a phone number
  /// </summary>
  /// <param name="userId">The ID of the user for whom the phone number should be added.</param>
  /// <param name="addPhoneRequest">The request body</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>User</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<User>> AddPhoneAsync(string userId, AddPhoneRequest addPhoneRequest, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (addPhoneRequest == null)
    {
      throw new ArgumentNullException(nameof(addPhoneRequest));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/phones?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("POST"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Content = new StringContent(Serialize(addPhoneRequest), Encoding.UTF8, "application/json"),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<User>(request, cancellationToken);
  }

  /// <summary>
  /// Remove a phone number
  /// </summary>
  /// <param name="userId">The ID of the user whose phone number should be removed.</param>
  /// <param name="identifierId">The ID of the phone number to be removed.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>User</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<User>> RemovePhoneAsync(string userId, Guid identifierId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (identifierId == null)
    {
      throw new ArgumentNullException(nameof(identifierId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var encodedIdentifierId = HttpUtility.UrlEncode(identifierId.ToString());

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/phones/{encodedIdentifierId}?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("DELETE"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<User>(request, cancellationToken);
  }

  /// <summary>
  /// Set phone as primary
  /// </summary>
  /// <param name="userId">The ID of the user whose phone should be set as primary.</param>
  /// <param name="identifierId">The ID of the phone to be set as primary.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>User</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<User>> SetPrimaryPhoneAsync(string userId, Guid identifierId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (identifierId == null)
    {
      throw new ArgumentNullException(nameof(identifierId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var encodedIdentifierId = HttpUtility.UrlEncode(identifierId.ToString());

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/phones/{encodedIdentifierId}/primary?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("POST"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<User>(request, cancellationToken);
  }

  /// <summary>
  /// Mark phone as verified
  /// </summary>
  /// <param name="userId">The ID of the user whose phone is to be marked as verified.</param>
  /// <param name="identifierId">The ID of the phone to be marked as verified.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>User</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<User>> SetPhoneVerifiedAsync(string userId, Guid identifierId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (identifierId == null)
    {
      throw new ArgumentNullException(nameof(identifierId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var encodedIdentifierId = HttpUtility.UrlEncode(identifierId.ToString());

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/phones/{encodedIdentifierId}/verify?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("POST"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<User>(request, cancellationToken);
  }

  /// <summary>
  /// Mark phone as unverified
  /// </summary>
  /// <param name="userId">The ID of the user whose phone is to be marked as unverified.</param>
  /// <param name="identifierId">The ID of the phone to be marked as unverified.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>User</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<User>> SetPhoneUnverifiedAsync(string userId, Guid identifierId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (identifierId == null)
    {
      throw new ArgumentNullException(nameof(identifierId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var encodedIdentifierId = HttpUtility.UrlEncode(identifierId.ToString());

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/phones/{encodedIdentifierId}/unverify?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("POST"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<User>(request, cancellationToken);
  }

  /// <summary>
  /// Remove passkey
  /// </summary>
  /// <param name="userId">The ID of the user from whose account the passkey should be removed.</param>
  /// <param name="passkeyId">The ID of the passkey to remove.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns></returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse> RemovePasskeyAsync(string userId, string passkeyId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (passkeyId == null)
    {
      throw new ArgumentNullException(nameof(passkeyId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var encodedPasskeyId = HttpUtility.UrlEncode(passkeyId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/passkeys/{encodedPasskeyId}?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("DELETE"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
    };

    return ProcessRequestAsync(request, cancellationToken);
  }

  /// <summary>
  /// Set password
  /// </summary>
  /// <param name="userId">The ID of the user whose password should be set.</param>
  /// <param name="setPasswordRequest">The set password request.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>User</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<User>> SetPasswordAsync(string userId, SetPasswordRequest setPasswordRequest, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (setPasswordRequest == null)
    {
      throw new ArgumentNullException(nameof(setPasswordRequest));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/password?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("PUT"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Content = new StringContent(Serialize(setPasswordRequest), Encoding.UTF8, "application/json"),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<User>(request, cancellationToken);
  }

  /// <summary>
  /// Remove password
  /// </summary>
  /// <param name="userId">The ID of the user whose password should be removed.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns></returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse> RemovePasswordAsync(string userId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/password?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("DELETE"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
    };

    return ProcessRequestAsync(request, cancellationToken);
  }

  /// <summary>
  /// Require user password reset
  /// </summary>
  /// <param name="userId">The ID of the user.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>User</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<User>> SetPasswordResetRequiredAsync(string userId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/password/force_reset?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("POST"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<User>(request, cancellationToken);
  }

  /// <summary>
  /// Remove user password reset requirement
  /// </summary>
  /// <param name="userId">The ID of the user.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>User</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<User>> RemovePasswordResetRequiredAsync(string userId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/password/force_reset?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("DELETE"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<User>(request, cancellationToken);
  }

  /// <summary>
  /// Password Reset
  /// </summary>
  /// <param name="userId">The ID of the user whose password reset link is requested.</param>
  /// <param name="resetPasswordRequest"></param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>ResetPasswordResponse</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<ResetPasswordResponse>> ResetPasswordAsync(string userId, ResetPasswordRequest resetPasswordRequest, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (resetPasswordRequest == null)
    {
      throw new ArgumentNullException(nameof(resetPasswordRequest));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/password/reset?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("POST"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Content = new StringContent(Serialize(resetPasswordRequest), Encoding.UTF8, "application/json"),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<ResetPasswordResponse>(request, cancellationToken);
  }

  /// <summary>
  /// Update user claims
  /// </summary>
  /// <param name="userId">The ID of the user whose claims should be updated.</param>
  /// <param name="updateClaimsRequest">The update claims request.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>User</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<User>> PatchClaimsAsync(string userId, UpdateClaimsRequest updateClaimsRequest, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (updateClaimsRequest == null)
    {
      throw new ArgumentNullException(nameof(updateClaimsRequest));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/claims?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("PATCH"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Content = new StringContent(Serialize(updateClaimsRequest), Encoding.UTF8, "application/json"),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<User>(request, cancellationToken);
  }

  /// <summary>
  /// Get user private data
  /// </summary>
  /// <param name="userId">The ID of the user whose private data should be retrieved.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>UserPrivateData</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<UserPrivateData>> GetPrivateDataAsync(string userId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/private_data?");

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

    return ProcessRequestAsync<UserPrivateData>(request, cancellationToken);
  }

  /// <summary>
  /// Update user private data
  /// </summary>
  /// <param name="userId">The ID of the user whose private data should be updated.</param>
  /// <param name="updatePrivateDataRequest">The update private data request.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>UserPrivateData</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<UserPrivateData>> PatchPrivateDataAsync(string userId, UpdatePrivateDataRequest updatePrivateDataRequest, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (updatePrivateDataRequest == null)
    {
      throw new ArgumentNullException(nameof(updatePrivateDataRequest));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/private_data?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("PATCH"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Content = new StringContent(Serialize(updatePrivateDataRequest), Encoding.UTF8, "application/json"),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<UserPrivateData>(request, cancellationToken);
  }

  /// <summary>
  /// Get user public data
  /// </summary>
  /// <param name="userId">The ID of the user whose public data should be retrieved.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>UserPublicData</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<UserPublicData>> GetPublicDataAsync(string userId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/public_data?");

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

    return ProcessRequestAsync<UserPublicData>(request, cancellationToken);
  }

  /// <summary>
  /// Update user public data
  /// </summary>
  /// <param name="userId">The ID of the user whose public data should be updated.</param>
  /// <param name="updatePublicDataRequest">The update public data request.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>UserPublicData</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<UserPublicData>> PatchPublicDataAsync(string userId, UpdatePublicDataRequest updatePublicDataRequest, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (updatePublicDataRequest == null)
    {
      throw new ArgumentNullException(nameof(updatePublicDataRequest));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/public_data?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("PATCH"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Content = new StringContent(Serialize(updatePublicDataRequest), Encoding.UTF8, "application/json"),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<UserPublicData>(request, cancellationToken);
  }

  /// <summary>
  /// Get all blocked IPs
  /// </summary>
  /// <param name="userId">The ID of the user whose blocked IP addresses should be retrieved.</param>
  /// <param name="page">The page number to retrieve.</param>
  /// <param name="size">The number of items per page.</param>
  /// <param name="filter">A query filter to apply when searching for blocked IPs.</param>
  /// <param name="sort">The sort criteria in &#39;sort_key:sort_order&#39; format. Sort order can be &#39;1&#39; for ascending and &#39;-1&#39; for descending.  Acceptable sort key values are &#39;block_until&#39; and &#39;last_sign_in_attempt&#39;.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>List&lt;UserIpAccessDetails&gt;</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<List<UserIpAccessDetails>, PageModel>> GetAllBlockedIpsAsync(string userId, int? page = 1, int? size = 10, string? filter = default, string? sort = default, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/blocked_ips?");

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

    return ProcessRequestAsync<List<UserIpAccessDetails>, PageModel>(request, cancellationToken);
  }

  /// <summary>
  /// Unblock an IP address
  /// </summary>
  /// <param name="userId">The ID of the user whose IP address should be unblocked.</param>
  /// <param name="unblockIpRequest">The unblock IP request</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>User</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<User>> UnblockIpAsync(string userId, UnblockIpRequest unblockIpRequest, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (unblockIpRequest == null)
    {
      throw new ArgumentNullException(nameof(unblockIpRequest));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/blocked_ips/unblock?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("POST"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Content = new StringContent(Serialize(unblockIpRequest), Encoding.UTF8, "application/json"),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<User>(request, cancellationToken);
  }

  /// <summary>
  /// Get all sessions
  /// </summary>
  /// <param name="userId">The ID of the user whose sessions should be retrieved.</param>
  /// <param name="page">The page number to retrieve.</param>
  /// <param name="size">The number of items per page.</param>
  /// <param name="clientId">The client ID by which the user sessions should be filtered.</param>
  /// <param name="sort">Specifies the sort criteria in the &#39;sort_key:sort_order&#39; format. The sort order value can be &#39;1&#39; for ascending and &#39;-1&#39; for descending.  Acceptable sort key values are &#39;session_id&#39;, &#39;initiated_at&#39;, &#39;expires_at&#39;, and &#39;last_updated&#39;.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>List&lt;UserSession&gt;</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<List<UserSession>, PageModel>> GetAllUserSessionsAsync(string userId, int? page = 1, int? size = 10, string? clientId = default, string? sort = default, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/sessions?");

    if (page != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("page") + "=").Append(HttpUtility.UrlEncode(page.ToString())).Append("&");
    }

    if (size != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("size") + "=").Append(HttpUtility.UrlEncode(size.ToString())).Append("&");
    }

    if (clientId != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("clientId") + "=").Append(HttpUtility.UrlEncode(clientId)).Append("&");
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

    return ProcessRequestAsync<List<UserSession>, PageModel>(request, cancellationToken);
  }

  /// <summary>
  /// Get a user session
  /// </summary>
  /// <param name="userId">The ID of the user whose session should be retrieved.</param>
  /// <param name="sessionId">The ID of the user session to be retrieved</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>UserSession</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<UserSession>> FindUserSessionEndpointAsync(string userId, string sessionId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (sessionId == null)
    {
      throw new ArgumentNullException(nameof(sessionId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var encodedSessionId = HttpUtility.UrlEncode(sessionId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/sessions/{encodedSessionId}?");

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

    return ProcessRequestAsync<UserSession>(request, cancellationToken);
  }

  /// <summary>
  /// Revoke a session
  /// </summary>
  /// <param name="userId">The ID of the user whose session should be revoked.</param>
  /// <param name="sessionId">The ID of the session to revoke.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns></returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse> RevokeUserSessionAsync(string userId, string sessionId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (sessionId == null)
    {
      throw new ArgumentNullException(nameof(sessionId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var encodedSessionId = HttpUtility.UrlEncode(sessionId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/sessions/{encodedSessionId}?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("DELETE"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
    };

    return ProcessRequestAsync(request, cancellationToken);
  }

  /// <summary>
  /// Disconnect external authenticator
  /// </summary>
  /// <param name="userId">The ID of the user from whom the external authenticator should be disconnected.</param>
  /// <param name="externalAuthenticatorDisconnectRequest">The disconnected external authenticator request.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>User</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<User>> ExternalAuthenticatorDisconnectAsync(string userId, ExternalAuthenticatorDisconnectRequest externalAuthenticatorDisconnectRequest, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (externalAuthenticatorDisconnectRequest == null)
    {
      throw new ArgumentNullException(nameof(externalAuthenticatorDisconnectRequest));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/external_authenticator/disconnect?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("POST"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Content = new StringContent(Serialize(externalAuthenticatorDisconnectRequest), Encoding.UTF8, "application/json"),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<User>(request, cancellationToken);
  }

  /// <summary>
  /// Get all user&#39;s groups
  /// </summary>
  /// <param name="userId">The ID of the user whose group assignments should be retrieved.</param>
  /// <param name="page">The page number to retrieve.</param>
  /// <param name="size">The number of items per page.</param>
  /// <param name="sort">Specifies the sort criteria in the &#39;sort_key:sort_order&#39; format. The sort order value can be &#39;1&#39; for ascending and &#39;-1&#39; for descending.  The acceptable sort key is &#39;creation_time&#39;.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>List&lt;UserGroup&gt;</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<List<UserGroup>, PageModel>> GetAllUserGroupsAsync(string userId, int? page = 1, int? size = 10, string? sort = default, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/groups?");

    if (page != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("page") + "=").Append(HttpUtility.UrlEncode(page.ToString())).Append("&");
    }

    if (size != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("size") + "=").Append(HttpUtility.UrlEncode(size.ToString())).Append("&");
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

    return ProcessRequestAsync<List<UserGroup>, PageModel>(request, cancellationToken);
  }

  /// <summary>
  /// Get a user group
  /// </summary>
  /// <param name="userId">The ID of the user whose group association should be retrieved.</param>
  /// <param name="groupId">The ID of the group to which the user is assigned.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>UserGroup</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<UserGroup>> FindUserGroupAsync(string userId, Guid groupId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (groupId == null)
    {
      throw new ArgumentNullException(nameof(groupId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var encodedGroupId = HttpUtility.UrlEncode(groupId.ToString());

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/groups/{encodedGroupId}?");

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

    return ProcessRequestAsync<UserGroup>(request, cancellationToken);
  }

  /// <summary>
  /// Assign user to group
  /// </summary>
  /// <param name="userId">The ID of the user to be assigned to the group.</param>
  /// <param name="groupId">The ID of the group to which the user will be assigned.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>UserGroup</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<UserGroup>> AssignUserToGroupAsync(string userId, Guid groupId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (groupId == null)
    {
      throw new ArgumentNullException(nameof(groupId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var encodedGroupId = HttpUtility.UrlEncode(groupId.ToString());

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/groups/{encodedGroupId}?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("POST"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
      Headers =
      {
        { "Accept", "application/json" }
      }
    };

    return ProcessRequestAsync<UserGroup>(request, cancellationToken);
  }

  /// <summary>
  /// Remove user from group
  /// </summary>
  /// <param name="userId">The ID of the user to be removed from the group.</param>
  /// <param name="groupId">The ID of the group from which the user should be removed.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns></returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse> RemoveUserFromGroupAsync(string userId, Guid groupId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (groupId == null)
    {
      throw new ArgumentNullException(nameof(groupId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var encodedGroupId = HttpUtility.UrlEncode(groupId.ToString());

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/groups/{encodedGroupId}?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("DELETE"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
    };

    return ProcessRequestAsync(request, cancellationToken);
  }

  /// <summary>
  /// Get all users in group
  /// </summary>
  /// <param name="groupId">The ID of the group whose users should be retrieved.</param>
  /// <param name="page">The page number to retrieve.</param>
  /// <param name="size">The number of items per page.</param>
  /// <param name="filter">A query filter to apply when searching for users.</param>
  /// <param name="sort">Specifies the sort criteria in the &#39;sort_key:sort_order&#39; format. The sort order value can be &#39;1&#39; for ascending and &#39;-1&#39; for descending.  Acceptable sort key values are &#39;creation_time&#39;, and &#39;last_updated&#39;.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>List&lt;UserSummary&gt;</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<List<UserSummary>, PageModel>> GetAllGroupAssignedUsersAsync(Guid groupId, int? page = 1, int? size = 10, string? filter = default, string? sort = default, CancellationToken cancellationToken = default)
  { 
    if (groupId == null)
    {
      throw new ArgumentNullException(nameof(groupId));
    }
    
    var encodedGroupId = HttpUtility.UrlEncode(groupId.ToString());

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/groups/{encodedGroupId}/assigned?");

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

    return ProcessRequestAsync<List<UserSummary>, PageModel>(request, cancellationToken);
  }

  /// <summary>
  /// Get all client grants
  /// </summary>
  /// <param name="userId">The ID of the user whose grants should be retrieved.</param>
  /// <param name="page">The page number to retrieve.</param>
  /// <param name="size">The number of items per page.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>List&lt;UserClientGrants&gt;</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<List<UserClientGrants>, PageModel>> GetAllUserClientGrantsAsync(string userId, int? page = 1, int? size = 10, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/grants/clients?");

    if (page != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("page") + "=").Append(HttpUtility.UrlEncode(page.ToString())).Append("&");
    }

    if (size != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("size") + "=").Append(HttpUtility.UrlEncode(size.ToString())).Append("&");
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

    return ProcessRequestAsync<List<UserClientGrants>, PageModel>(request, cancellationToken);
  }

  /// <summary>
  /// Get all consents
  /// </summary>
  /// <param name="userId">The ID of the user whose consents should be retrieved.</param>
  /// <param name="page">The page number to retrieve.</param>
  /// <param name="size">The number of items per page.</param>
  /// <param name="clientId">The client ID by which the grants should be filtered.</param>
  /// <param name="sort">Specifies the sort criteria in the &#39;sort_key:sort_order&#39; format. The sort order value can be &#39;1&#39; for ascending and &#39;-1&#39; for descending.  Acceptable sort key values are &#39;creation_time&#39; and &#39;expiration&#39;.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>List&lt;UserConsent&gt;</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<List<UserConsent>, PageModel>> GetAllUserConsentsAsync(string userId, int? page = 1, int? size = 10, string? clientId = default, string? sort = default, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/grants/consents?");

    if (page != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("page") + "=").Append(HttpUtility.UrlEncode(page.ToString())).Append("&");
    }

    if (size != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("size") + "=").Append(HttpUtility.UrlEncode(size.ToString())).Append("&");
    }

    if (clientId != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("clientId") + "=").Append(HttpUtility.UrlEncode(clientId)).Append("&");
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

    return ProcessRequestAsync<List<UserConsent>, PageModel>(request, cancellationToken);
  }

  /// <summary>
  /// Get all reference tokens
  /// </summary>
  /// <param name="userId">The ID of the user whose tokens should be retrieved.</param>
  /// <param name="page">The page number to retrieve.</param>
  /// <param name="size">The number of items per page.</param>
  /// <param name="clientId">The client ID by which the grants should be filtered.</param>
  /// <param name="sessionId">The session ID by which the grants should be filtered.</param>
  /// <param name="sort">Specifies the sort criteria in the &#39;sort_key:sort_order&#39; format. The sort order value can be &#39;1&#39; for ascending and &#39;-1&#39; for descending.  Acceptable sort key values are &#39;creation_time&#39; and &#39;expiration&#39;.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>List&lt;ReferenceToken&gt;</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<List<ReferenceToken>, PageModel>> GetAllReferenceTokensAsync(string userId, int? page = 1, int? size = 10, string? clientId = default, string? sessionId = default, string? sort = default, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/grants/reference_tokens?");

    if (page != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("page") + "=").Append(HttpUtility.UrlEncode(page.ToString())).Append("&");
    }

    if (size != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("size") + "=").Append(HttpUtility.UrlEncode(size.ToString())).Append("&");
    }

    if (clientId != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("clientId") + "=").Append(HttpUtility.UrlEncode(clientId)).Append("&");
    }

    if (sessionId != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("sessionId") + "=").Append(HttpUtility.UrlEncode(sessionId)).Append("&");
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

    return ProcessRequestAsync<List<ReferenceToken>, PageModel>(request, cancellationToken);
  }

  /// <summary>
  /// Get all refresh tokens
  /// </summary>
  /// <param name="userId">The ID of the user whose tokens should be retrieved.</param>
  /// <param name="page">The page number to retrieve.</param>
  /// <param name="size">The number of items per page.</param>
  /// <param name="clientId">The client ID by which the grants should be filtered.</param>
  /// <param name="sessionId">The session ID by which the grants should be filtered.</param>
  /// <param name="sort">Specifies the sort criteria in the &#39;sort_key:sort_order&#39; format. The sort order value can be &#39;1&#39; for ascending and &#39;-1&#39; for descending.  Acceptable sort key values are &#39;creation_time&#39; and &#39;expiration&#39;.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>List&lt;RefreshToken&gt;</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<List<RefreshToken>, PageModel>> GetAllRefreshTokensAsync(string userId, int? page = 1, int? size = 10, string? clientId = default, string? sessionId = default, string? sort = default, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/grants/refresh_tokens?");

    if (page != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("page") + "=").Append(HttpUtility.UrlEncode(page.ToString())).Append("&");
    }

    if (size != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("size") + "=").Append(HttpUtility.UrlEncode(size.ToString())).Append("&");
    }

    if (clientId != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("clientId") + "=").Append(HttpUtility.UrlEncode(clientId)).Append("&");
    }

    if (sessionId != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("sessionId") + "=").Append(HttpUtility.UrlEncode(sessionId)).Append("&");
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

    return ProcessRequestAsync<List<RefreshToken>, PageModel>(request, cancellationToken);
  }

  /// <summary>
  /// Get all authorization codes
  /// </summary>
  /// <param name="userId">The ID of the user whose authorization codes should be retrieved.</param>
  /// <param name="page">The page number to retrieve.</param>
  /// <param name="size">The number of items per page.</param>
  /// <param name="clientId">The client ID by which the grants should be filtered.</param>
  /// <param name="sessionId">The session ID by which the grants should be filtered.</param>
  /// <param name="sort">Specifies the sort criteria in the &#39;sort_key:sort_order&#39; format. The sort order value can be &#39;1&#39; for ascending and &#39;-1&#39; for descending.  Acceptable sort key values are &#39;creation_time&#39; and &#39;expiration&#39;.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns>List&lt;AuthorizationCode&gt;</returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse<List<AuthorizationCode>, PageModel>> GetAllAuthorizationCodesAsync(string userId, int? page = 1, int? size = 10, string? clientId = default, string? sessionId = default, string? sort = default, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/grants/codes?");

    if (page != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("page") + "=").Append(HttpUtility.UrlEncode(page.ToString())).Append("&");
    }

    if (size != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("size") + "=").Append(HttpUtility.UrlEncode(size.ToString())).Append("&");
    }

    if (clientId != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("clientId") + "=").Append(HttpUtility.UrlEncode(clientId)).Append("&");
    }

    if (sessionId != null)
    {
      urlBuilder.Append(Uri.EscapeDataString("sessionId") + "=").Append(HttpUtility.UrlEncode(sessionId)).Append("&");
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

    return ProcessRequestAsync<List<AuthorizationCode>, PageModel>(request, cancellationToken);
  }

  /// <summary>
  /// Revoke client grants
  /// </summary>
  /// <param name="userId">The ID of the user whose token should be revoked.</param>
  /// <param name="clientId">The ID of the client whose grants should be revoked.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns></returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse> RevokeUserClientGrantsAsync(string userId, string clientId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (clientId == null)
    {
      throw new ArgumentNullException(nameof(clientId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var encodedClientId = HttpUtility.UrlEncode(clientId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/grants/clients/{encodedClientId}?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("DELETE"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
    };

    return ProcessRequestAsync(request, cancellationToken);
  }

  /// <summary>
  /// Revoke a consent
  /// </summary>
  /// <param name="userId">The ID of the user whose consent should be revoked.</param>
  /// <param name="consentId">The ID of the consent to be revoked.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns></returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse> RevokeUserConsentAsync(string userId, string consentId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (consentId == null)
    {
      throw new ArgumentNullException(nameof(consentId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var encodedConsentId = HttpUtility.UrlEncode(consentId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/grants/consents/{encodedConsentId}?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("DELETE"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
    };

    return ProcessRequestAsync(request, cancellationToken);
  }

  /// <summary>
  /// Revoke a reference token
  /// </summary>
  /// <param name="userId">The ID of the user whose token should be revoked.</param>
  /// <param name="tokenId">The ID of the token to be revoked.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns></returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse> RevokeReferenceTokenAsync(string userId, string tokenId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (tokenId == null)
    {
      throw new ArgumentNullException(nameof(tokenId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var encodedTokenId = HttpUtility.UrlEncode(tokenId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/grants/reference_tokens/{encodedTokenId}?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("DELETE"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
    };

    return ProcessRequestAsync(request, cancellationToken);
  }

  /// <summary>
  /// Revoke a refresh token
  /// </summary>
  /// <param name="userId">The ID of the user whose token should be revoked.</param>
  /// <param name="tokenId">The ID of the token to be revoked.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns></returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse> RevokeRefreshTokenAsync(string userId, string tokenId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (tokenId == null)
    {
      throw new ArgumentNullException(nameof(tokenId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var encodedTokenId = HttpUtility.UrlEncode(tokenId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/grants/refresh_tokens/{encodedTokenId}?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("DELETE"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
    };

    return ProcessRequestAsync(request, cancellationToken);
  }

  /// <summary>
  /// Revoke an authorization code
  /// </summary>
  /// <param name="userId">The ID of the user whose authorization code should be revoked.</param>
  /// <param name="codeId">The ID of the authorization code to be revoked.</param>
  /// <param name="cancellationToken">The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.</param>
  /// <returns></returns>
  /// <exception cref="MonoCloudException">A server side error occurred.</exception>
  public Task<MonoCloudResponse> RevokeAuthorizationCodeAsync(string userId, string codeId, CancellationToken cancellationToken = default)
  { 
    if (userId == null)
    {
      throw new ArgumentNullException(nameof(userId));
    }
    
    if (codeId == null)
    {
      throw new ArgumentNullException(nameof(codeId));
    }
    
    var encodedUserId = HttpUtility.UrlEncode(userId);

    var encodedCodeId = HttpUtility.UrlEncode(codeId);

    var urlBuilder = new StringBuilder();
    urlBuilder.Append($"users/{encodedUserId}/grants/codes/{encodedCodeId}?");

    urlBuilder.Length--;

    var request = new HttpRequestMessage
    {
      Method = new HttpMethod("DELETE"),
      RequestUri = new Uri(urlBuilder.ToString(), UriKind.RelativeOrAbsolute),
    };

    return ProcessRequestAsync(request, cancellationToken);
  }
}

