namespace BethanysPieShop.Models
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly BethanysPieShopContext _context;
        public string ShoppingCartId { get; set; }
        public ShoppingCartRepository(BethanysPieShopContext context)
        {
            _context = context;
        }

        public static ShoppingCartRepository GetCart(IServiceProvider serviceProvider)
        {
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            BethanysPieShopContext context = serviceProvider.GetService<BethanysPieShopContext>()
                ?? throw new Exception("Error");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCartRepository(context) { ShoppingCartId = cartId };            
        }
        public IEnumerable<ShoppingCartItem> ShoppingCartItems { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        
        public Pie AddItemToCart(Pie pieToAdd)
        {
            var shoppingCartItem = _context.ShoppingCartItems
                                    .SingleOrDefault(p => p.Pie == pieToAdd && 
                                         p.ShoppingCartId == ShoppingCartId);

            if(shoppingCartItem is null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Pie = pieToAdd,
                    Quantity = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }

            shoppingCartItem.Quantity += 1;
            _context.SaveChanges();

            return pieToAdd;
        }

        public void ClearCart()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShoppingCartItem> GetAddedItems()
        {
            throw new NotImplementedException();
        }

        public decimal GetCartTotal()
        {
            throw new NotImplementedException();
        }

        public void RemoveItemFromCart(Pie pieToRemove)
        {
            throw new NotImplementedException();
        }
    }
}
