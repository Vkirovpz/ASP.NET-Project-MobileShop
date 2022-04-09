namespace MobileShop.Controllers.Api
{
    using Microsoft.AspNetCore.Mvc;
    using MobileShop.Domain.Phones.ServiceModels;
    using MobileShop.Models.Api.Phones;

    [ApiController]
    [Route("api/phones")]
    public class PhonesApiController : ControllerBase
    {
        private IPhoneService phones;

        public PhonesApiController(IPhoneService phones)=> this.phones = phones;
        

        public PhoneQueryServiceModel All([FromQuery] AllPhonesApiRequestModel query)
        => this.phones.All(
                query.Brand,
                query.Category,
                query.SearchTerm,
                query.CurrentPage,
                query.PhonesPerPage);
    }
}
