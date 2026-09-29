using System;
using System.Collections.Generic;
using System.Text;
using MoviesArchive.Domain.Models.Users;

namespace MoviesArchive.Domain.Interfaces;

public interface IPasswordHasherService
{
    string Hash(User user, string password);
    bool Compare(User user, string hashedPass, string password);
}
