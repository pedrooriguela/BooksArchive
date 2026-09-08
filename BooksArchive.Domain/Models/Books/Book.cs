using BooksArchive.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksArchive.Domain.Models.Books;

public class Book : Entity
{
    public string Title { get; set; }
    public string Autor { get; set; }

}
