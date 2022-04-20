using System.ComponentModel.DataAnnotations;

namespace MobileShop.Data.Entities
{
    public class CartItem
    {
        [Key]
        public string ItemId { get; set; }

        public string CartId { get; set; }

        public int Quantity { get; set; }

        public int PhoneId { get; set; }

        public virtual Phone Phone { get; set; }

    }
}

