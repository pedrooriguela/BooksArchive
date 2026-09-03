using BooksArchive.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksArchive.Infra.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);
}
