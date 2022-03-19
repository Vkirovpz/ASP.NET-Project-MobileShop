using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShop.Domain.Phones.ServiceModels
{
    public interface IPhoneService
    {
        public IEnumerable<PhoneBrandServiceModel> GetBrands();

        public IEnumerable<PhoneCategoryServiceModel> GetCategories();
    }
}
