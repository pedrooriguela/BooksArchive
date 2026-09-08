using System;
using System.Collections.Generic;
using System.Text;

namespace BooksArchive.Domain.Interfaces;

public interface IOpenLibraryConsumer
{
    Task<HttpResponseMessage> GetBook(string name);
}
