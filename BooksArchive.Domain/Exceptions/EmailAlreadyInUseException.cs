using System;
using System.Collections.Generic;
using System.Text;

namespace BooksArchive.Domain.Exceptions;

public class EmailAlreadyInUseException : Exception
{
    public EmailAlreadyInUseException() : base("Este email já está em uso por uma conta ativa") { }
}
