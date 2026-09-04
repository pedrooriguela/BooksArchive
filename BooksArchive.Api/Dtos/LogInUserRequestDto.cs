using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BooksArchive.Api.Dtos;

public class LogInUserRequestDto
{
    [Required(ErrorMessage = "Preencha o campo de nome de usuário")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Preencha o campo de senha")]
    public string Password { get; set; }
}
