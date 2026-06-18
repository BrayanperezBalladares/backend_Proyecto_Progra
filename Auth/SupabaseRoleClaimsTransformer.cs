using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Text.Json;

namespace ProyectoIProgra2.Auth
{
    public class SupabaseRoleClaimsTransformer : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var identity = (ClaimsIdentity)principal.Identity!;

            var appMetaRaw = identity.FindFirst("app_metadata")?.Value;
            string role = "cliente";

            if (!string.IsNullOrEmpty(appMetaRaw))
            {
                try
                {
                    var meta = JsonSerializer.Deserialize<JsonElement>(appMetaRaw);
                    if (meta.TryGetProperty("role", out var roleProp))
                        role = roleProp.GetString() ?? "cliente";
                }
                catch { /* malformed claim → default to cliente */ }
            }

            if (!identity.HasClaim(ClaimTypes.Role, role))
                identity.AddClaim(new Claim(ClaimTypes.Role, role));

            return Task.FromResult(principal);
        }
    }
}
