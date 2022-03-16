using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MobileShop.Data.DataConstants.Phone;

namespace MobileShop.Data.Entities
{
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

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public int ModelId { get; set; }

        public Model Model { get; set; }

        public int DealerId { get; init; }

        public Dealer Dealer { get; init; }

        public int CategoryId { get; init; }

        public Category Category { get; init; }

    }
}
