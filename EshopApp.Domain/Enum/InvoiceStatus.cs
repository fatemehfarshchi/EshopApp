namespace EshopApp.Domain.Enums
{
    /// <summary>
    /// Represents the status of an invoice.
    /// </summary>
    public enum InvoiceStatus
    {
        /// <summary>
        /// The invoice is in draft state and not finalized.
        /// </summary>
        Draft = 0,

        /// <summary>
        /// The invoice has been paid.
        /// </summary>
        Paid = 1,

        /// <summary>
        /// The invoice has been canceled.
        /// </summary>
        Canceled = 2
    }
}
