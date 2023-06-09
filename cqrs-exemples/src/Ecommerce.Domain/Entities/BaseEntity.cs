﻿using FluentValidation;
using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ecommerce.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }

        private DateTime? _createdAt;

        public DateTime? CreatedAt
        {
            get => _createdAt;
            set => _createdAt = (value == null ? DateTime.UtcNow : value);
        }

        public DateTime? UpdatedAt { get; set; }

        [NotMapped]
        [JsonIgnore]
        public bool Valid { get; protected set; }

        [NotMapped]
        [JsonIgnore]
        public ValidationResult ValidationResult { get; protected set; }

        public bool EntityValidation<T>(T model, AbstractValidator<T> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }
    }
}
