namespace MobileShop.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static MobileShop.Data.DataConstants.Phone;
    public class Phone
    {
        public int Id { get; init; }

        [Required]
        [StringLength(ColorMaxLength, MinimumLength = ColorMinLength)]
        public string Color { get; set; }


        [Required]
        [StringLength(OverviewMaxLength, MinimumLength = OverviewMinLength)]
        public string Overview { get; set; }


        [Required]
        [MaxLength(ImageUrlMaxLength)]
        [Url]
        public string ImageUrl { get; set; }


        [Required]
        [Range(MinPrice, MaxPrice)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(ModelMaxLength, MinimumLength = ModelMinLength)]
        public string Model { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public int DealerId { get; set; }

        public Dealer Dealer { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();

    }
}
