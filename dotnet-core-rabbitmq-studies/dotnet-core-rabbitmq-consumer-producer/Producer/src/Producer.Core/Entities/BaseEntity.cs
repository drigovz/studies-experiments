using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.Results;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Producer.Core.Entities;

public abstract class BaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    private ObjectId _id;
    public ObjectId Id
    {
        get => _id;
        set => _id = ObjectId.GenerateNewId();
    }

    private DateTime _createdAt;
    public DateTime CreatedAt
    {
        get => _createdAt;
        set => _createdAt = DateTime.UtcNow;
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