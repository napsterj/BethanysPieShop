namespace BethanysPieShop.Models
{
    public class ShoppingCartItem
    {
        public string? ShoppingCartItemId { get; set; }
        public Pie? Pie { get; set; } = default;
        public int? Quantity { get; set; }
        public string? ShoppingCartId { get; set; }
    }
}
