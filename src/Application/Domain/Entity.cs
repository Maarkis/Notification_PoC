using System;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public bool Valid { get; private set; }
        public bool Invalid => !Valid;
        public ValidationResult ValidationResult { get; private set; }

        public bool Validate<T>(T entity, AbstractValidator<T> validator)
        {
            ValidationResult = validator.Validate(entity);
            return Valid = ValidationResult.IsValid;
        }
    }
}