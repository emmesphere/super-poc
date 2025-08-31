using System.Text.RegularExpressions;

namespace SuperPoc.BuildingBlocks.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        private Email(string value)
        {
            Value = value;
        }

        public static Email Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("E-mail não pode ser vazio.");

            if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("E-mail inválido.");

            return new Email(value);
        }
        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value?.ToLowerInvariant();
        }

        public override string ToString() => Value ?? string.Empty;
    }
}
