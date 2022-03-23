namespace MobileShop.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static MobileShop.Data.DataConstants.Brand;
    public class Brand
    {
        public int Id { get; init; }

        [Required]
        [StringLength(BrandMaxLength, MinimumLength = BrandMinLength)]
        public string Name { get; set; }

        public ICollection<Phone> Phones { get; set; } = new HashSet<Phone>();
    }
}
