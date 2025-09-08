using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

[ApiController]
[Route("[controller]")]
public class SampleController : ControllerBase
{
    private readonly IMemoryCache _cache;

    public SampleController(IMemoryCache cache)
    {
        _cache = cache;
    }

    [HttpGet]
    public IActionResult Get()
    {
        const string cacheKey = "sampleData";
        if (!_cache.TryGetValue(cacheKey, out string data))
        {
            // Simulate data fetching
            data = "This is cached data";
            _cache.Set(cacheKey, data, TimeSpan.FromMinutes(5));
        }
        return Ok(data);
    }
}