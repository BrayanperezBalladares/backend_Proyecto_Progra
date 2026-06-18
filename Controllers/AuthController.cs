using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ProyectoIProgra2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthController(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            _config = config;
            _httpClientFactory = httpClientFactory;
        }

        // POST: api/Auth/staff
        [HttpPost("staff")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CrearStaff([FromBody] CreateStaffDto dto)
        {
            var serviceKey = _config["SUPABASE_SERVICE_ROLE_KEY"]
                ?? throw new InvalidOperationException("SUPABASE_SERVICE_ROLE_KEY is required");

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", serviceKey);
            client.DefaultRequestHeaders.Add("apikey", serviceKey);

            var body = JsonSerializer.Serialize(new
            {
                email = dto.Email,
                password = dto.Password,
                email_confirm = true,
                app_metadata = new { role = "recepcionista" }
            });

            var response = await client.PostAsync(
                "https://mmmfeijsrhchdivgwzhm.supabase.co/auth/v1/admin/users",
                new StringContent(body, Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                return BadRequest(error);
            }

            return Ok(new { message = "Staff account created", email = dto.Email });
        }
    }

    public class CreateStaffDto
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
