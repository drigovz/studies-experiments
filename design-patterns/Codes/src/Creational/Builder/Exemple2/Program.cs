using Builder;

var emailBuilder = new EmailBuilder()
    .To("email@exemple.com")
    .From("email2@email.com")
    .Subject("Subject email")
    .Body("Message body")
    .Build();

Console.WriteLine(emailBuilder);
Console.ReadKey();