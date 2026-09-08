using BooksArchive.Domain.Interfaces;
using BooksArchive.Infra.Settings;
using Microsoft.Extensions.Configuration;

namespace BooksArchive.Infra.Consumers;

public class OpenLibraryConsumer : IOpenLibraryConsumer
{
    private readonly HttpClient _httpClient;
    private readonly OpenLibraryApiSettings _openLibraryApiSettings;

    public OpenLibraryConsumer (
        HttpClient httpClient,
        IConfiguration configuration)
    {
        _httpClient = httpClient;
        _openLibraryApiSettings = configuration.GetSection("OpenLibraryApiSettings").Get<OpenLibraryApiSettings>()!;
    }

    public async Task<HttpResponseMessage> GetBook(string name)
    {
        return await _httpClient.GetAsync($"{_openLibraryApiSettings.BaseUrl}/search.json?title={name}");
    }

}
