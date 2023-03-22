using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Goodreads.Core.Entities;

public abstract class BaseEntity
{
    private Guid _id;
    public Guid Id
    {
        get => _id;
        set =>  _id = Guid.NewGuid();
    }

    private DateTime? _createdAt;

    public DateTime? CreatedAt
    {
        get => _createdAt;
        set => _createdAt = value ?? DateTime.UtcNow;
    }

    public DateTime? UpdatedAt { get; set; }

    [NotMapped]
    [JsonIgnore]
    public bool Valid { get; protected set; }

    [NotMapped]
    [JsonIgnore]
    public ValidationResult? ValidationResult { get; protected set; }

    protected bool EntityValidation<T>(T model, AbstractValidator<T> validator)
    {
        ValidationResult = validator.Validate(model);
        return Valid = ValidationResult.IsValid;
    }
}