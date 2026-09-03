using BooksArchive.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksArchive.Domain.Models;

public class User : Entity
{
    public User(
        string name,
        string email,
        string password,
        Guid id)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public class Builder
    {
        public static User Create(string name, string email, string password) =>
            new(name, email, password, Guid.NewGuid());
    }
}
