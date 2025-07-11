using System.ComponentModel.DataAnnotations.Schema;

namespace EshopApp.Domain.ValueObjects
{
    /// <summary>
    /// Represents a value object for an address, including city, street, and postal code.
    /// </summary>
    [NotMapped]
    public class Address
    {
        /// <summary>
        /// The city of the address.
        /// </summary>
        public string? City { get; private set; }

        /// <summary>
        /// The street of the address.
        /// </summary>
        public string? Street { get; private set; }

        /// <summary>
        /// The postal code of the address.
        /// </summary>
        public string? PostalCode { get; private set; }

        /// <summary>
        /// Private constructor for EF Core and serialization.
        /// </summary>
        private Address() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> value object.
        /// </summary>
        /// <param name="city">The city of the address.</param>
        /// <param name="street">The street of the address.</param>
        /// <param name="postalCode">The postal code of the address.</param>
        public Address(string city, string street, string postalCode)
        {
            City = city;
            Street = street;
            PostalCode = postalCode;
        }

        /// <summary>
        /// Returns a string representation of the address.
        /// </summary>
        /// <returns>A string in the format "Street, City, PostalCode".</returns>
        public override string ToString()
        {
            return $"{Street}, {City}, {PostalCode}";
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current address.
        /// </summary>
        /// <param name="obj">The object to compare with the current address.</param>
        /// <returns>True if the specified object is equal to the current address; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not Address other) return false;
            return City == other.City && Street == other.Street && PostalCode == other.PostalCode;
        }

        /// <summary>
        /// Returns a hash code for the address.
        /// </summary>
        /// <returns>A hash code for the current address.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(City, Street, PostalCode);
        }
    }
}
