using System;
using System.Globalization;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Represent the year of a vehicle is matriculated.
    /// </summary>
    [Serializable]
    public sealed class Year : IEquatable<Year>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Year"/> class.
        /// </summary>
        /// <param name="value">The year of matriculate vehicle value.</param>
        public Year(int value)
        {
            if (value < 1900 || value > DateTime.UtcNow.Year)
            {
                throw new ArgumentException("Invalid matriculate year. Must be greater than 1900", nameof(value));
            }

            Value = value;
        }

        private Year()
        {
        }

        /// <summary>
        /// Gets the year vehicle.
        /// </summary>
        public int Value { get; private set; }

        /// <inheritdoc/>
        public bool Equals(Year other) => other != null && Value == other.Value;

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as Year);

        /// <inheritdoc/>
        public override int GetHashCode() => Value.GetHashCode();

        /// <inheritdoc/>
        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);
    }
}
