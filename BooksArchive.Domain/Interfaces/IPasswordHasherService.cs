using BooksArchive.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksArchive.Domain.Interfaces;

public interface IPasswordHasherService
{
    string Hash(User user, string password);
    bool Compare(User user, string hashedPass, string password);
}
