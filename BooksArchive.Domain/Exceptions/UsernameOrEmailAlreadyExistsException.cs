using System;
using System.Collections.Generic;
using System.Text;

namespace BooksArchive.Domain.Exceptions;

public class UsernameOrEmailAlreadyExistsException : Exception
{
    public UsernameOrEmailAlreadyExistsException() : base("Email ou username já estão em uso") { }
}
