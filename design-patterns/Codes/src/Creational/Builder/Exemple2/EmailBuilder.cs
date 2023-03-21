namespace Builder;

internal class EmailBuilder
{
    private readonly Email _email;

    public EmailBuilder()
    {
        _email = new Email();
    }

    public EmailBuilder To(string destiny)
    {
        _email.To = destiny;
        return this;
    }

    public EmailBuilder From(string origin)
    {
        _email.From = origin;
        return this;
    }

    public EmailBuilder Subject(string subject)
    {
        _email.Subject = subject;
        return this;
    }

    public EmailBuilder Body(string body)
    {
        _email.Body = body;
        return this;
    }

    public Email Build() => _email;
}
