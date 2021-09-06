using RDIDigitalTest.Domain.Core.Interfaces.Service;
using RDIDigitalTest.Domain.Entities.CostumerCard;
using System;
using Xunit;

namespace RDIDigitalTest.Domain.Services.Tests
{
    public class CostumerCardServiceTests
    {
        private readonly ICostumerCardService costumerCardService;
        private readonly CostumerCard costumerCard;

        public CostumerCardServiceTests()
        {
            costumerCard = new CostumerCard(1, 1234567891234567, 3, DateTime.UtcNow);
        }

        [Fact]
        public void ValidatedToken()
        {
            //Act
            var isValid = costumerCardService.isValidToken(costumerCard.CostumerId, costumerCard.Id, costumerCard.GetCostumerCardToken(), costumerCard.CVV);

            //Assert
            Assert.True(isValid);
        }
    }
}
