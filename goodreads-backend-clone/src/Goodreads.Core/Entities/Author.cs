using Goodreads.Core.Enums;
using Goodreads.Core.Validations;

namespace Goodreads.Core.Entities;

public sealed class Author : BaseEntity
{
    public string Name { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public DateTime Birthdate { get; private set; }
    public string Website { get; private set; }
    public string Description { get; private set; }
    public Gender Gender { get; private set; }

    public Author(string name, string city, string state, string country, DateTime birthdate, string website, string description, Gender gender)
    {
        Name = name;
        City = city;
        State = state;
        Country = country;
        Birthdate = birthdate;
        Website = website;
        Description = description;
        Gender = gender;
        
        EntityValidation(this, new AuthorValidation());
    }

    public Author Update(string name, string city, string state, string country, DateTime birthdate, string website, string description, Gender gender)
    {
        Name = name;
        City = city;
        State = state;
        Country = country;
        Birthdate = birthdate;
        Website = website;
        Description = description;
        Gender = gender;

        EntityValidation(this, new AuthorValidation());
        
        return this;
    }

    public string GetBornDescription() =>
        $"in {City}, {State}, {Country} \n{Birthdate:dd MMMM, yyyy}";
}