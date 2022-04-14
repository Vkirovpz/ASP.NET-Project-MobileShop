using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Domain.Phones.ServiceModels
{
    public class IndexServiceModel
    {
        public int TotalPhones { get; init; }
        public int TotalUsers { get; init; }
        public IList<PhoneIndexServiceModel> Phones { get; init; }
    }
}
