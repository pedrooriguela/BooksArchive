using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesArchive.Domain.Exceptions;

public class UsernameAlreadyInUseException : Exception
{
    public UsernameAlreadyInUseException() : base("Este nome de usuário já está em uso por uma conta ativa") { }
}
