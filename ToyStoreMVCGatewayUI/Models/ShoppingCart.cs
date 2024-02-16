using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToyStoreMVCGatewayUI.Models
{
    [Table("ShoppingCart")]
    public class ShoppingCart
    {
        [Key]
        public int ShoppingCartId { get; set; }
        [Required]
        public string UserId { get; set; }
        public bool IsDeleted { get; set; } = false;

        public ICollection<CartDetail> CartDetails { get; set; }

    }
}
