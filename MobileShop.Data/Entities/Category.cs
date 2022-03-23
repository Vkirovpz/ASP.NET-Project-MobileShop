namespace MobileShop.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Category
    {
        public int Id { get; init; }

        [Required]
        public string Name { get; set; }

        public ICollection<Phone> Phones { get; set; } = new HashSet<Phone>();
    }
}
