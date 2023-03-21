namespace Builder.WthoutFluentBuilder;

internal class Email
{
    public string To { get; set; }
    public string From { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }

    public override string ToString() =>
        $"Destiny: {To} \nOrigin: {From} \nSubject: {Subject} \nMessage: {Body}";
}