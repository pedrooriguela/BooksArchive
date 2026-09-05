using BooksArchive.Domain.Interfaces;
using BooksArchive.Domain.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace BooksArchive.Infra.Services;

public class PasswordHasherService : IPasswordHasherService
{
    public PasswordHasherService()
    {
        hasher = new PasswordHasher<User>();
    }

    public PasswordHasher<User> hasher { get; set; }

    public string Hash(User user, string password) => 
        hasher.HashPassword(user, password);
    

    public bool Compare(User user, string hashedPass, string password)
    {
        var ret = hasher.VerifyHashedPassword(user, hashedPass, password);

        if (ret == PasswordVerificationResult.Success)
            return true;

        return false;
    }
}
