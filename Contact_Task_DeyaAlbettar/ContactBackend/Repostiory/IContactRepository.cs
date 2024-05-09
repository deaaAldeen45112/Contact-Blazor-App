using Microsoft.AspNetCore.Mvc;
using SharedModels.Models;

namespace ContactBackend.Repostiory
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(int id);
        Task<Contact> AddAsync(Contact contact);
        Task<Contact> UpdateAsync(Contact contact);
        Task DeleteAsync(int id);
        Task<bool> ContactExistsAsync(int contactId);
    }
}
