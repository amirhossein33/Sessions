namespace Simplicity_Driven_Development.Sample1
{
    //False
    // اشتباه: آماده‌سازی برای ویژگی‌ای که فعلاً نیاز نیست.
    public class Order
    {
        public string? OrderId { get; set; }
        public string? Status { get; set; }
        public string? TrackingInfo { get; set; } // فعلاً این ویژگی موردنیاز نیست.

        public void UpdateTracking(string trackingDetails)
        {
            TrackingInfo = trackingDetails; // کدی که فعلاً بی‌استفاده است.
        }
    }

}
//True
public class Order
{
    public string? OrderId { get; set; }
    public string? Status { get; set; }
    // ویژگی‌های اضافی اضافه نمی‌شوند.
}
