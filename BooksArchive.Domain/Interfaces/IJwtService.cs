using BooksArchive.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksArchive.Domain.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}
