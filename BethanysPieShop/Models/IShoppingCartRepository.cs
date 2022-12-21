namespace BethanysPieShop.Models
{
    public interface IShoppingCartRepository
    {
        IEnumerable<ShoppingCartItem> GetAddedItems();
        Pie AddItemToCart(Pie pieToAdd); 
        void RemoveItemFromCart(Pie pieToRemove);
        void ClearCart();
        decimal GetCartTotal();
        IEnumerable<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
