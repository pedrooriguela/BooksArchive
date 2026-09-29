namespace MoviesArchive.Domain.Dtos;

public class SendEmailDto
{
    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}