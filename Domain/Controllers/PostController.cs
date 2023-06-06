using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Domain.Models;

namespace Domain.Controllers;

[ApiController]
[Route("api/Domain/[controller]")]
public class PostController : ControllerBase
{
    private readonly string? _dalUrl;
    private readonly HttpClient _post;

    public PostController(IConfiguration conf)
    {
        _dalUrl = conf.GetValue<string>("DalUrl");
        _post = new HttpClient();
    }

    [HttpGet("Get")]
    public async Task<ActionResult<Post[]>> GetPosts()
    {
        var response = await _post.GetAsync($"{_dalUrl}/api/Post/getPosts");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        if (content == null) return NotFound();

        return JsonSerializer.Deserialize<Post[]>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? Array.Empty<Post>();
    }
}