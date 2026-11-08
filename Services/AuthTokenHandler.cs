using System.Net.Http.Headers;
namespace RaceDay_MVC.Services
{
    public class AuthTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthTokenHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Grab the JWT token we saved in the cookie during Login
            var token = _httpContextAccessor.HttpContext?.Request.Cookies["JwtToken"];

            if (!string.IsNullOrEmpty(token))
            {
                // Attach it to the request header so the API authorizes it
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}