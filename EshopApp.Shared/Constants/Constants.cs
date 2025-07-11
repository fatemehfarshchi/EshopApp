namespace EshopApp.Shared.Constants;

public static class AppConstants
{
    public const string DefaultStoreName = "فروشگاه من";
    public const string DefaultPhoneNumber = "02100000000";
    public const string DefaultAddress = "تهران، ایران";
    public const string DefaultLogoUrl = "/images/default-logo.png";

    public const string PersianCulture = "fa-IR";
    public const string DateFormat = "yyyy/MM/dd";
    public static class ErrorMessages
    {
        public const string InvalidProductId = "شناسه محصول نامعتبر است.";
        public const string ProductNotFound = "محصول یافت نشد.";
        public const string CategoryNotFound = "دسته‌بندی یافت نشد.";
        public const string InvoiceNotFound = "فاکتور یافت نشد.";
        public const string ValidationFailed = "اعتبارسنجی داده‌ها با شکست مواجه شد.";
    }
}
