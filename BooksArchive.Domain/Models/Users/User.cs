using BooksArchive.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace BooksArchive.Domain.Models.Users;

public class User : Entity
{
    public User(
        string name,
        string email,
        Guid id)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public void SetPassword (string password) =>
        Password = password;

    public class Builder
    {
        public static User Create(string name, string email) =>
            new(name, email, Guid.NewGuid());
    }
}
