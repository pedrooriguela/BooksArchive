using BooksArchive.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksArchive.Infra.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<bool> UpdateAsync(Guid id, string name, string password);
    Task<bool> Delete(Guid id);
    Task<User?> GetByIdAsync(Guid id);
    User? GetByUsername(string username);
    User? GetByEmail(string email);
}
