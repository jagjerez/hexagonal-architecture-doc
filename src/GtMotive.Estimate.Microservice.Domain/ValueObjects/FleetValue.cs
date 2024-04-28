using System;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Represent a fleet vehicle.
    /// </summary>
    [Serializable]
    public sealed class FleetValue : IEquatable<FleetValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FleetValue"/> class.
        /// </summary>
        /// <param name="value">The Fleet code value.</param>
        public FleetValue(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Fleet cannot be empty.", nameof(value));
            }

            Value = value;
        }

        private FleetValue()
        {
        }

        /// <summary>
        /// Gets the brand vehicle.
        /// </summary>
        public string Value { get; private set; }

        /// <inheritdoc/>
        public bool Equals(FleetValue other) => other != null && Value == other.Value;

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as FleetValue);

        /// <inheritdoc/>
        public override int GetHashCode() => Value.GetHashCode(StringComparison.InvariantCulture);

        /// <inheritdoc/>
        public override string ToString() => Value;
    }
}
