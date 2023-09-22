namespace FreeCourse.Web.Models.Baskets
{
    public class BasketItemViewModel
    {
        public int Quantity { get; set; } = 1;
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public decimal Price { get; set; }

        private decimal? DicountAppliedPrice;

        public decimal GetCurrentPrice => DicountAppliedPrice != null ? DicountAppliedPrice.Value : Price;

        public void AppliedDiscount(decimal discountPrice)
        {
            DicountAppliedPrice = discountPrice;
        }
    }
}
