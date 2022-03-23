namespace MobileShop.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static MobileShop.Data.DataConstants.User;
    public class User:IdentityUser
    {

        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; }

    }
}
