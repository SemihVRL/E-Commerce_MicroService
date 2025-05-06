namespace E_Commerce.Discount.Entities
{
    public class Coupon
    {
        public int CouponId { get; set; }
        public string Code { get; set; }//indirim kuponu
        public int Rate { get; set; } // indirim oranı
        public bool IsActive { get; set; }// kupon aktif mi değil mi
        public DateTime ValidDate { get; set; }//geçerlilik süresi
    }
}
