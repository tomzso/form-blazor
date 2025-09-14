using BlazorApp4.Models;


namespace BlazorApp4.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ContextService _contextService;
        private readonly string _formApiUrl;

        public AuthService(HttpClient httpClient, IConfiguration configuration, ContextService contextService)
        {
            _httpClient = httpClient;
            _formApiUrl = configuration["ApiSettings:FormApiUrl"];
            _contextService = contextService;
        }

        public async Task<(bool Success, string Message, string Token)> Login(LoginModel model)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_formApiUrl}/account/login", model);

            if (response.IsSuccessStatusCode)
            {
                var authResponse = await response.Content.ReadFromJsonAsync<AuthResponseModel>();
                if (authResponse != null && !string.IsNullOrEmpty(authResponse.Token))
                {
                    // Example: store token in local storage or memory
                    // await _localStorage.SetItemAsync("authToken", authResponse.Token);
                    _contextService.Token = authResponse.Token;
                    return (true, "Login successful!", authResponse.Token);
                }
                return (false, "Login succeeded but no token returned.", null);
            }

            return (false, $"Login failed: {response.StatusCode}", null);
        }

        public async Task<(bool Success, string Message, string Token)> Register(RegisterModel model)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_formApiUrl}/account/register", model);

            if (response.IsSuccessStatusCode)
            {
                var authResponse = await response.Content.ReadFromJsonAsync<AuthResponseModel>();
                if (authResponse != null && !string.IsNullOrEmpty(authResponse.Token))
                {
                    _contextService.Token = authResponse.Token;
                    return (true, "Registration successful!", authResponse.Token);
                }
                return (false, "Registration succeeded but no token returned.", null);
            }

            return (false, $"Registration failed: {response.StatusCode}", null);
        }

    }




}
