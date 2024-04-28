using System;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Represent a plate vehicle code.
    /// </summary>
    [Serializable]
    public sealed class PlateCode : IEquatable<PlateCode>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlateCode"/> class.
        /// </summary>
        /// <param name="value">The code plate value.</param>
        public PlateCode(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Code plate cannot be empty.", nameof(value));
            }

            Value = value;
        }

        private PlateCode()
        {
        }

        /// <summary>
        /// Gets the plate vehicle.
        /// </summary>
        public string Value { get; private set; }

        /// <inheritdoc/>
        public bool Equals(PlateCode other) => other != null && Value == other.Value;

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as PlateCode);

        /// <inheritdoc/>
        public override int GetHashCode() => Value.GetHashCode(StringComparison.InvariantCulture);

        /// <inheritdoc/>
        public override string ToString() => Value;
    }
}
