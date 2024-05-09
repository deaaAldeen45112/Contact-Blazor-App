
using SharedModels.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;

namespace Contact_Task_DeyaAlbettar.Service
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
            return await _httpClient.GetFromJsonAsync<List<Contact>>(TABLE_NAME);
        }

        public async Task<Contact> GetContactAsync(int contactId)
        {
            return await _httpClient.GetFromJsonAsync<Contact>($"{TABLE_NAME}/{contactId}");
        }

        public async Task<Contact> CreateContactAsync(Contact contact)
        {
            var response = await _httpClient.PostAsJsonAsync(TABLE_NAME, contact);
            return await response.Content.ReadFromJsonAsync<Contact>();
        }

        public async Task<Contact> UpdateContactAsync(Contact contact)
        {
            var response = await _httpClient.PutAsJsonAsync($"{TABLE_NAME}/{contact.ContactId}", contact);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Contact>();
            }
            return null;
        }

        public async Task DeleteContactAsync(int contactId)
        {
            await _httpClient.DeleteAsync($"{TABLE_NAME}/{contactId}");
        }
    }
}
