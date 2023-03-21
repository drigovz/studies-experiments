namespace Builder.WthoutFluentBuilder;

internal class EmailBuilder
{
    private readonly Email _email;

    public EmailBuilder()
    {
        _email = new Email();
    }

    public void To(string destiny)
    {
        _email.To = destiny;
    }

    public void From(string origin)
    {
        _email.From = origin;
    }

    public void Subject(string subject)
    {
        _email.Subject = subject;
    }

    public void Body(string body)
    {
        _email.Body = body;
    }

    public Email Build() => _email;
}
