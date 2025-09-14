using BlazorApp4.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace BlazorApp4.Services
{
    public class FormService
    {
        private readonly HttpClient _httpClient;
        private readonly string _formApiUrl;
        private readonly ContextService _contextService;

        public FormService(HttpClient httpClient, IConfiguration configuration, ContextService contextService)
        {
            _httpClient = httpClient;
            _formApiUrl = configuration["ApiSettings:FormApiUrl"];
            _contextService = contextService;
        }

        public async Task<List<FormModel>?> GetFormsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<FormModel>>($"{_formApiUrl}/form/all");
        }

        public async Task<FormModel?> GetFormByUrlAsync(string url)
        {
            AddAuthHeader();
            return await _httpClient.GetFromJsonAsync<FormModel>($"{_formApiUrl}/form/url/{url}");
        }
        public async Task<FormResponseModel?> GetUserFormResponseAsync(int formid)
        {
            AddAuthHeader();
            return await _httpClient.GetFromJsonAsync<FormResponseModel>($"{_formApiUrl}/formresponse/formid/{formid}");
        }


        public async Task<bool> CreateFormUserAnswerAsync(int responseId, int fieldId, string value)
        {
            AddAuthHeader();

            var request = new FieldResponseModel
            {
                ResponseId = responseId,
                FieldId = fieldId,
                Value = value
            };

            var response = await _httpClient.PostAsJsonAsync($"{_formApiUrl}/fieldResponse", request);

            return response.IsSuccessStatusCode;
        }

        public async Task<int?> CreateFormResponseAsync(int formId)
        {
            AddAuthHeader();

            var response = await _httpClient.PostAsJsonAsync($"{_formApiUrl}/formresponse/{formId}", new { });

            if (response.IsSuccessStatusCode)
            {
                var responseObj = await response.Content.ReadFromJsonAsync<FormResponseIdModel>();
                return responseObj?.Id;
            }

            return null;
        }


        private void AddAuthHeader()
        {
            if (!string.IsNullOrEmpty(_contextService.Token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _contextService.Token);
            }
        }
    }
}
