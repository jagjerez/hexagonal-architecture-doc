using System;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Represent customer code identity of reald world.
    /// </summary>
    [Serializable]
    public sealed class CustomerIdentity : IEquatable<CustomerIdentity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerIdentity"/> class.
        /// </summary>
        /// <param name="value">The brand vehicle value.</param>
        public CustomerIdentity(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Customer identity cannot be empty.", nameof(value));
            }

            Value = value;
        }

        private CustomerIdentity()
        {
        }

        /// <summary>
        /// Gets the brand vehicle.
        /// </summary>
        public string Value { get; private set; }

        /// <inheritdoc/>
        public bool Equals(CustomerIdentity other) => other != null && Value == other.Value;

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as CustomerIdentity);

        /// <inheritdoc/>
        public override int GetHashCode() => Value.GetHashCode(StringComparison.InvariantCulture);

        /// <inheritdoc/>
        public override string ToString() => Value;
    }
}
