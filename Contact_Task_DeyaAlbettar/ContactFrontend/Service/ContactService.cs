
using SharedModels.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Json;

namespace ContactFrontend.Service
{
    public class ContactService
    {
        private readonly HttpClient _httpClient;
        private static readonly string TABLE_NAME="contacts";
        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Contact>> GetContactsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<List<Contact>>>(TABLE_NAME);

            return response.Data;
        }

        public async Task<Contact> GetContactAsync(int contactId)
        {
            var response = await _httpClient.GetAsync($"{TABLE_NAME}/{contactId}");
            if (response.IsSuccessStatusCode)
            {

                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<Contact>>();
                return apiResponse.Data;
            }
            else {
                throw new Exception("");
            }
  
           
        }

        public async Task<Contact> CreateContactAsync(Contact contact)
        {
            var response = await _httpClient.PostAsJsonAsync(TABLE_NAME, contact);
            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<Contact>>();

            if (apiResponse!=null && apiResponse.ErrorMessage == "Validation failed") {
                
                throw new ValidationException(string.Join("\n", apiResponse.ValidationErrors));

            }
            if (!response.IsSuccessStatusCode || apiResponse == null)
            {
                throw new InvalidOperationException(apiResponse?.ErrorMessage ?? "Server error");
            }
            if (!apiResponse.Success)
            {
                throw new ApplicationException(apiResponse.ErrorMessage);
            }

            return apiResponse.Data;
        }

        public async Task<string> UpdateContactAsync(Contact contact)
        {

            var response = await _httpClient.PutAsJsonAsync($"{TABLE_NAME}/{contact.ContactId}", contact);
            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();

            if (apiResponse != null && apiResponse.ErrorMessage == "Validation failed")
            {

                throw new ValidationException(string.Join("\n", apiResponse.ValidationErrors));

            }
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException(apiResponse?.ErrorMessage ?? "Server error");
            }
            if (apiResponse != null && !apiResponse.Success)
            {
                throw new ApplicationException(apiResponse.ErrorMessage);
            }

            return apiResponse.Data;
        }

        public async Task<string> DeleteContactAsync(int contactId)
        {
            var response = await _httpClient.DeleteAsync($"{TABLE_NAME}/{contactId}");

            var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();

            if (apiResponse != null && apiResponse.ErrorMessage == "Validation failed")
            {

                throw new ValidationException(string.Join("\n", apiResponse.ValidationErrors));

            }
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException(apiResponse?.ErrorMessage ?? "Server error");
            }
            if (apiResponse != null && !apiResponse.Success)
            {
                throw new ApplicationException(apiResponse.ErrorMessage);
            }
            return apiResponse.Data;
        }
    }
}
