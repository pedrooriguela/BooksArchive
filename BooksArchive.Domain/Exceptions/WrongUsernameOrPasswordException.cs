using System;
using System.Collections.Generic;
using System.Text;

namespace BooksArchive.Domain.Exceptions;

public class WrongUsernameOrPasswordException : Exception
{
    public WrongUsernameOrPasswordException() : base("O nome de usuário ou a senha estão incorretos") { }
}
