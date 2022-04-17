namespace MobileShop.Tests.Controllers
{
    using MobileShop.Controllers;
    using MobileShop.Data.Entities;
    using MobileShop.Models.Dealers;
    using MobileShop.Models.Phones;
    using MyTested.AspNetCore.Mvc;
    using System.Linq;
    using Xunit;
    public class DealersControllerTest
    {
        [Fact]
        public void GetBecomeShouldBeForAuthorizedUsersAndReturnView()
            => MyController<DealersController>
                .Instance()
                .Calling(c => c.Become())
                .ShouldHave()
                .ActionAttributes(attributes => attributes
                    .RestrictingForAuthorizedRequests())
                .AndAlso()
                .ShouldReturn()
                .View();

        [Theory]
        [InlineData("Dealer", "+359888888888")]
        public void PostBecomeShouldBeForAuthorizedUsersAndReturnRedirectWithValidModel(
            string dealerName,
            string phoneNumber)
            => MyController<DealersController>
                .Instance(controller => controller
                    .WithUser())
                .Calling(c => c.Become(new BecomeDealerFormModel
                {
                    Name = dealerName,
                    PhoneNumber = phoneNumber
                }))
                .ShouldHave()
                .ActionAttributes(attributes => attributes
                    .RestrictingForHttpMethod(HttpMethod.Post)
                    .RestrictingForAuthorizedRequests())
                .ValidModelState()
                .Data(data => data
                    .WithSet<Dealer>(dealers => dealers
                        .Any(d =>
                            d.Name == dealerName &&
                            d.PhoneNumber == phoneNumber &&
                            d.UserId == TestUser.Identifier)))
                .AndAlso()
                .ShouldReturn()
                .Redirect(redirect => redirect
                    .To<PhonesController>(c => c.All(With.Any<AllPhonesQueryModel>())));


        [Fact]
        public void GetBecomeShouldBeForAuthorizedUsersAndReturnViewPipelineTest()
          => MyPipeline
              .Configuration()
              .ShouldMap(request => request
                  .WithPath("/Dealers/Become")
                  .WithUser())
              .To<DealersController>(c => c.Become())
              .Which()
              .ShouldHave()
              .ActionAttributes(attributes => attributes
                  .RestrictingForAuthorizedRequests())
              .AndAlso()
              .ShouldReturn()
              .View();
    }
}
