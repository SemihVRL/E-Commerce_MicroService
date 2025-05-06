namespace E_Commerce.Discount.Dtos
{
    public class CreateDiscountCouponDto
    {
        
        public string Code { get; set; }//indirim kuponu
        public int Rate { get; set; } // indirim oranı
        public bool IsActive { get; set; }// kupon aktif mi değil mi
        public DateTime ValidDate { get; set; }//geçerlilik süresi
    }
}
