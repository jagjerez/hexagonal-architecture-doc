using System;

namespace GtMotive.Estimate.Microservice.Domain.ValueObjects
{
    /// <summary>
    /// Represent a model vehicle.
    /// </summary>
    [Serializable]
    public sealed class Model : IEquatable<Model>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Model"/> class.
        /// </summary>
        /// <param name="value">The brand vehicle value.</param>
        public Model(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Model cannot be empty.", nameof(value));
            }

            Value = value;
        }

        private Model()
        {
        }

        /// <summary>
        /// Gets the model vehicle.
        /// </summary>
        public string Value { get; private set; }

        /// <inheritdoc/>
        public bool Equals(Model other) => other != null && Value == other.Value;

        /// <inheritdoc/>
        public override bool Equals(object obj) => Equals(obj as Model);

        /// <inheritdoc/>
        public override int GetHashCode() => Value.GetHashCode(StringComparison.InvariantCulture);

        /// <inheritdoc/>
        public override string ToString() => Value;
    }
}
