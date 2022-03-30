namespace MobileShop.Controllers.Api
{
    using Microsoft.AspNetCore.Mvc;
    using MobileShop.Domain.Phones.ServiceModels;
    using System.Collections;

    [ApiController]
    [Route("api/phones")]
    public class PhonesApiController :ControllerBase
    {
        private readonly IPhoneService phones;

        public PhonesApiController(IPhoneService phones)
        {
            this.phones = phones;
        }

     
    }
}
