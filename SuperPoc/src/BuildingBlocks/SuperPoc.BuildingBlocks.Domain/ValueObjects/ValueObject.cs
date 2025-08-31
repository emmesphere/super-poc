﻿namespace SuperPoc.BuildingBlocks.Domain.ValueObjects
{
    public abstract class ValueObject
    {
        public string? Value { get; init; }
        protected abstract IEnumerable<object?> GetEqualityComponents();
        public override bool Equals(object? obj)
        {
            if (obj is not ValueObject other) return false;
            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Aggregate(1, (current, obj) =>
                {
                    unchecked { return current * 23 + (obj?.GetHashCode() ?? 0); }
                });
        }
        public static bool operator ==(ValueObject a, ValueObject b) => Equals(a, b);
        public static bool operator !=(ValueObject a, ValueObject b) => !Equals(a, b);
    }
}
