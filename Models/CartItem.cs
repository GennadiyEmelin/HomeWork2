using System.ComponentModel.DataAnnotations.Schema;

namespace HomeWork2.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("ShoppingCartId")]
        public virtual Cart Cart { get; set; }

    }
}
