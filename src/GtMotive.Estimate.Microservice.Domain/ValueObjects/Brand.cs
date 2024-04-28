using System;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Represent a brand vehicle.
    /// </summary>
    [Serializable]
    public sealed class Brand : IEquatable<Brand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Brand"/> class.
        /// </summary>
        /// <param name="value">The brand vehicle value.</param>
        public Brand(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Brand cannot be empty.", nameof(value));
            }

            Value = value;
        }

        private Brand()
        {
        }

        /// <summary>
        /// Gets the brand vehicle.
        /// </summary>
        public string Value { get; private set; }

        /// <inheritdoc/>
        public bool Equals(Brand other) => other != null && Value == other.Value;

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as Brand);

        /// <inheritdoc/>
        public override int GetHashCode() => Value.GetHashCode(StringComparison.InvariantCulture);

        /// <inheritdoc/>
        public override string ToString() => Value;
    }
}
