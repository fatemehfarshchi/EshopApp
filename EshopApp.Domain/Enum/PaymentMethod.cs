namespace EshopApp.Domain.Enums
{
    /// <summary>
    /// Represents the payment method used for an invoice.
    /// </summary>
    public enum PaymentMethod
    {
        /// <summary>
        /// Payment is made in cash.
        /// </summary>
        Cash = 0,

        /// <summary>
        /// Payment is made by card.
        /// </summary>
        Card = 1,

        /// <summary>
        /// Payment is made online.
        /// </summary>
        Online = 2
    }
}
