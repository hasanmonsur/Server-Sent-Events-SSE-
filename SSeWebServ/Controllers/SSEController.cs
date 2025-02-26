using Microsoft.AspNetCore.Mvc;

namespace SSeWebServ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SseController : ControllerBase
    {
        [HttpGet("updates")]
        public async Task GetUpdates()
        {
            Response.Headers.Add("Content-Type", "text/event-stream");
            Response.Headers.Add("Cache-Control", "no-cache");
            Response.Headers.Add("Connection", "keep-alive");

            for (int i = 0; i < 10; i++)
            {
                string data = $"Event {i + 1}: This is a real-time update!";
                await Response.WriteAsync($"data: {data}\n\n");
                await Response.Body.FlushAsync();
                await Task.Delay(2000); // Simulate a delay between updates
            }

            await Response.WriteAsync("data: [END]\n\n");
            await Response.Body.FlushAsync();
        }
    }
}
