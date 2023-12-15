using MonoCloud.SDK.UsersBackend.Models;
using Moq;
using Moq.Contrib.HttpClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace MonoCloud.SDK.UsersBackend.UnitTests;

public class SDKTests
{
  private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
  private Dictionary<string, object> _requestMessage = new();
  private readonly MonoCloudUsersBackendClient _usersClient;

  public SDKTests()
  {
    _httpMessageHandlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
    var httpClient = _httpMessageHandlerMock.CreateClient();
    httpClient.BaseAddress = new Uri("https://mock.com");
    _usersClient = new MonoCloudUsersBackendClient(httpClient);
  }

  [Fact]
  public async Task Create_should_only_send_set_fields()
  {
    SetMockResponse(new CreateUserRequest());

    await _usersClient.CreateUserAsync(new CreateUserRequest()
    {
      Name = "user"
    });

    Assert.NotEmpty(_requestMessage);
    Assert.Equal("user", _requestMessage["name"]);
    Assert.Single(_requestMessage);
  }

  [Fact]
  public async Task Create_should_send_correct_enum()
  {
    SetMockResponse(new ExternalAuthenticatorDisconnectRequest());

    await _usersClient.ExternalAuthenticatorDisconnectEndpointAsync("user", new ExternalAuthenticatorDisconnectRequest
    {
      Authenticator = ExternalAuthenticators.Apple
    });

    Assert.NotEmpty(_requestMessage);
    Assert.Equal("apple", _requestMessage["authenticator"]);
    Assert.Single(_requestMessage);
  }

  [Fact]
  public async Task Patch_should_send_null_fields_when_set()
  {
    SetMockResponse(new UserPrivateData());

    await _usersClient.PatchPrivateDataAsync("1234", new UpdatePrivateDataRequest
    {
      PrivateData = new Dictionary<string, object>
      {
        { "Test", null! }
      }
    });

    Assert.NotEmpty(_requestMessage);
    var data = JsonConvert.DeserializeObject<Dictionary<string, object>>((_requestMessage["private_data"] as JObject)!.ToString())!;
    Assert.Null(data["Test"]);
    Assert.Single(data);
  }

  [Fact]
  public async Task Get_should_receive_correct_datetime()
  {
    var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

    SetMockResponse(new
    {
      creation_time = now
    });

    var result = await _usersClient.FindUserByIdAsync("user");

    Assert.NotNull(result);
    Assert.Equivalent(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(now), result.Data.CreationTime);
  }

  [Fact]
  public async Task Get_should_receive_correct_nullable_datetime()
  {
    SetMockResponse(new
    {
      password_updated_at = (long?)null
    });

    var result = await _usersClient.FindUserByIdAsync("user");

    Assert.Null(result.Data.PasswordUpdatedAt);
  }


  [Fact]
  public async Task Get_with_paging_should_receive_correct_result()
  {
    SetMockResponse(new List<User>
    {
      new(),
      new()
    }, headers: new Dictionary<string, string>
    {
      { "x-Pagination", """{"total_count":20,"page_size":2,"current_page":3,"has_next":true,"has_previous":true}""" }
    });

    var result = await _usersClient.GetAllUsersAsync();

    Assert.Equal(2, result.Data.Count);
    Assert.Equal(20, result.PageData.TotalCount);
    Assert.Equal(2, result.PageData.PageSize);
    Assert.Equal(3, result.PageData.CurrentPage);
    Assert.True(result.PageData.HasNext);
    Assert.True(result.PageData.HasPrevious);
  }

  [Fact]
  public async Task Get_with_paging_should_handle_no_pagination_header()
  {
    SetMockResponse(new List<User>
    {
      new(),
      new()
    });

    var result = await _usersClient.GetAllUsersAsync();

    Assert.Equal(2, result.Data.Count);
    Assert.Equal(0, result.PageData.TotalCount);
    Assert.Equal(0, result.PageData.PageSize);
    Assert.Equal(0, result.PageData.CurrentPage);
    Assert.False(result.PageData.HasNext);
    Assert.False(result.PageData.HasPrevious);
  }

  private void SetMockResponse(object request, HttpStatusCode code = HttpStatusCode.OK, IDictionary<string, string>? headers = null) =>
    _httpMessageHandlerMock.SetupRequest(async message =>
    {
      try
      {
        var val = await message.Content!.ReadAsStringAsync();
        _requestMessage = JsonConvert.DeserializeObject<Dictionary<string, object>>(val)!;
      }
      catch
      {
        //
      }
      return true;
    }).ReturnsJsonResponse(code, request, configure: (message) =>
    {
      if (headers is not null)
      {
        foreach (var httpResponseHeader in headers)
        {
          message.Headers.Add(httpResponseHeader.Key, httpResponseHeader.Value);
        }
      }
    });
}
