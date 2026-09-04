using System;
using System.Collections.Generic;
using System.Text;

namespace BooksArchive.Domain.Exceptions;

public class WrongUsernameOrPasswordException : Exception
{
    public WrongUsernameOrPasswordException() : base("Pelo menos um dos campos está incorreto") { }
}
