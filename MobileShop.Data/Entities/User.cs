using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static MobileShop.Data.DataConstants.User;

namespace MobileShop.Data.Entities
{
    public class User:IdentityUser
    {

        [MaxLength(FullNameMaxLength)]
        public string FullName { get; set; }

    }
}
