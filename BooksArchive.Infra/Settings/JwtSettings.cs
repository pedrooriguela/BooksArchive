using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace BooksArchive.Infra.Settings;

public class JwtSettings
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
}
